using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEDC.NotesApp.Dtos;
using SEDC.NotesApp.Services.Interfaces;

namespace SEDC.NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService) //DI
        {
            _noteService = noteService;
        }

        [HttpGet]
        public ActionResult<List<NoteDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public ActionResult<NoteDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("addNote")]
        public IActionResult AddNote([FromBody] AddNoteDto addNoteDto)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult UpdateNote([FromBody] UpdateNoteDto updateNoteDto)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            throw new NotImplementedException();
        }
    }
}
