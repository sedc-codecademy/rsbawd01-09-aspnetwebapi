using ControllersSample.Data;
using ControllersSample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControllersSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        [HttpGet("getAllNotes")]
        public ActionResult GetAll() 
        {
            //if(parameter == null) 
            //    return BadRequest("Error, the provided value is null");
           
            return Ok(StaticDB.SimpleNotes);
        }

        // URL: http://localhost:8888/api/note/10
        [HttpGet("{id}")]
        public ActionResult Get(int id) 
        {
            if (id == 0) 
                return BadRequest("The provided value is not valid value");

            string value = StaticDB.SimpleNotes[id];

            return Ok(value);
        }

        // URL: http://localhost:8888/api/note/10/noteData/2 -- userId and noteIndex as params
        [HttpGet("{userId}/noteData/{noteIndex}")]
        public ActionResult CustomNote(int userId, int noteIndex) 
        {
            if (userId == 0)
                return BadRequest($"There is no user with provided {userId}");

            if (noteIndex < 0)
                return BadRequest($"There is no note with provided {noteIndex}");

            string value = StaticDB.SimpleNotes[noteIndex];

            return Ok(value);
        }

        [HttpPost("createNote")]
        public ActionResult Create([FromBody] Note model) 
        {
            if (model == null)
                return BadRequest("The provided value is null");

            StaticDB.SimpleNotes.Add(model.Content);

            return Ok(model.Content);    
        }

        [HttpDelete("deleteNoteByIndex/{index}")]
        public ActionResult Delete(int index)
        {
            try
            {
                StaticDB.SimpleNotes.RemoveAt(index);

                return Ok();
            }
            catch (Exception)
            {
                // Logg the exception to some file, data or external logging service
                return StatusCode(500, "There was a error on the server side, we are looking into the issue");
            } 
        }

        [HttpPut("updateNote")]
        public ActionResult Update([FromBody] Note model) 
        {
            try
            {
                if (model == null)
                    return BadRequest("The provided value is null");

                int index = StaticDB.SimpleNotes.IndexOf(model.Content);
                StaticDB.SimpleNotes.RemoveAt(index);

                StaticDB.SimpleNotes.Insert(index, model.Content);

                return Ok();
            }
            catch (Exception)
            {
                // Logg the exception to some file, data or external logging service
                return StatusCode(500, "There was a error on the server side, we are looking into the issue");
            }
        }
    }
}
