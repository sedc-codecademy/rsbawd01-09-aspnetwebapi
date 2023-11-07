using SEDC.NotesApp.Dtos;
using SEDC.NotesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.NotesApp.Services.Implementations
{
    public class FakeNoteService : INoteService
    {
        public void AddNote(AddNoteDto note)
        {
            throw new NotImplementedException();
        }

        public void DeleteNote(int id)
        {
            throw new NotImplementedException();
        }

        public List<NoteDto> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public NoteDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNote(UpdateNoteDto note)
        {
            throw new NotImplementedException();
        }
    }
}
