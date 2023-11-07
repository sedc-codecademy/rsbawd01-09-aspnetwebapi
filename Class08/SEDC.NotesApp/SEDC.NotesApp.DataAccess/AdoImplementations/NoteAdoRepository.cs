using Microsoft.Data.SqlClient;
using SEDC.NotesApp.Domain.Enums;
using SEDC.NotesApp.Domain.Models;

namespace SEDC.NotesApp.DataAccess.AdoImplementations
{
    public class NoteAdoRepository : IRepository<Note>
    {
        private string _connectionString;

        public NoteAdoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Note entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Note entity)
        {
            throw new NotImplementedException();
        }

        public List<Note> GetAll()
        {
            throw new NotImplementedException();
        }

        public Note GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}
