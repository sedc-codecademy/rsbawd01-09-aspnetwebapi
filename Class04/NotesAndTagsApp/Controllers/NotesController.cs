using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesAndTagsApp.Database;
using NotesAndTagsApp.DTOs;
using NotesAndTagsApp.Models;

namespace NotesAndTagsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet("getAll")]
        public ActionResult<List<NoteDto>> Get()
        {
            try
            {
                List<Note> notesDb = StaticDb.Notes;

                List<NoteDto> notes = notesDb.Select(x => new NoteDto
                {
                    Priority = x.Priority,
                    Text = x.Text,
                    User = $"{x.User.FirstName} {x.User.LastName}",
                    Tags = x.Tags.Select(t => t.Name).ToList()
                }).ToList();

                return Ok(notes);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<NoteDto> GetNoteById(int id)
        {
            try
            {
                if(id < 0)
                    return BadRequest("The id can not be negative!");

                //try to find the note by id
                Note noteDb = StaticDb.Notes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

                if(noteDb == null)
                    return NotFound($"Note with id {id} does not exist!");

                NoteDto noteDto = new NoteDto
                {
                    Priority = noteDb.Priority,
                    Text = noteDb.Text,
                    User = $"{noteDb.User.FirstName} {noteDb.User.LastName}",
                    Tags = noteDb.Tags.Select(t => t.Name).ToList()
                };

                return Ok(noteDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured");
            }
        }

        [HttpGet("findById")] //http://localhost:[port]/api/notes/findById?id=2
        public ActionResult<NoteDto> FindById(int id) //id is a query string param
        {
            try
            {
                if (id < 0)
                    return BadRequest("The id can not be negative!");

                Note noteDb = StaticDb.Notes.FirstOrDefault(x => x.Id == id);

                if (noteDb == null)
                    return NotFound($"Note with id {id} does not exist!");

                NoteDto noteDto = new NoteDto
                {
                    Priority = noteDb.Priority,
                    Text = noteDb.Text,
                    User = $"{noteDb.User.FirstName} {noteDb.User.LastName}",
                    Tags = noteDb.Tags.Select(t => t.Name).ToList()
                };

                return Ok(noteDto);
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateNoteDto updateNoteDto)
        {
            try
            {
                //validations
                Note noteDb = StaticDb.Notes
                    .Where(x => x.Id == updateNoteDto.Id)
                    .FirstOrDefault();

                if (noteDb == null)
                    return NotFound($"Note with id {updateNoteDto.Id} was not found!");

                if (string.IsNullOrEmpty(updateNoteDto.Text))
                    return BadRequest($"Text is a required field");

                User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == updateNoteDto.UserId);

                if(userDb == null)
                    return NotFound($"User with id {updateNoteDto.UserId} was not found!");

                List<Tag> tags = new List<Tag>();
                
                foreach(int tagId in updateNoteDto.TagIds)
                {
                    Tag tagDb = StaticDb.Tags
                        .Where(x => x.Id == tagId)
                        .FirstOrDefault();
                
                    if(tagDb == null)
                        return NotFound($"Tag with id {tagId} was not found!");
                    
                    tags.Add(tagDb);
                }

                //update
                noteDb.Text = updateNoteDto.Text;
                noteDb.Priority = updateNoteDto.Priority;
                noteDb.User = userDb;
                noteDb.UserId = userDb.Id;
                noteDb.Tags = tags;

                //return result
                return Ok("Note updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                if(id <= 0)
                    return BadRequest("Id has invalid value");

                Note noteDb = StaticDb.Notes
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
               
                if(noteDb == null)
                    return NotFound($"Note with id {id} was not found!");

                StaticDb.Notes.Remove(noteDb);
                
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }

        [HttpGet("user/{userId}")] //route params note/user/10
        public ActionResult<List<NoteDto>> GetNotesByUser(int userId)
        {
            try
            {
                //if no notes are found for the userId, userNotes will be an empty collection
                List<Note> userNotes = StaticDb.Notes.Where(x => x.UserId == userId).ToList();
                
                List<NoteDto> userNotesDto = userNotes.Select(x => new NoteDto
                {
                    Priority = x.Priority,
                    Text = x.Text,
                    User = $"{x.User.FirstName} {x.User.LastName}",
                    Tags = x.Tags.Select(t => t.Name).ToList()
                }).ToList();

                return Ok(userNotesDto);
            }
            catch
            {
                //log
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }

        [HttpPost("addNote")]
        public IActionResult AddNote([FromBody] AddNoteDto addNoteDto)
        {
            try
            {
                //validations
                if (string.IsNullOrEmpty(addNoteDto.Text))
                    return BadRequest($"Text is a required field");

                User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == addNoteDto.UserId);
                
                if (userDb == null)
                    return NotFound($"User with id {addNoteDto.UserId} was not found!");

                List<Tag> tags = new List<Tag>();
                
                foreach (int tagId in addNoteDto.TagIds)
                {
                    Tag tagDb = StaticDb.Tags.FirstOrDefault(x => x.Id == tagId);
                
                    if (tagDb == null)
                        return NotFound($"Tag with id {tagId} was not found!");
                    
                    tags.Add(tagDb);
                }

                //create
                Note newNote = new Note
                {
                    Id = ++StaticDb.NoteId, //first we increment StaticDb.NoteId, then we assign it to Id
                    Text = addNoteDto.Text,
                    Priority = addNoteDto.Priority,
                    User = userDb,
                    UserId = addNoteDto.UserId,
                    Tags = tags
                };

                StaticDb.Notes.Add(newNote);
                
                //return Ok();
                
                return StatusCode(StatusCodes.Status201Created, "Note created!");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured, contact the admin!");
            }
        }
    }
}
