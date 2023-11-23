using DataModels;

namespace DataAccess
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NotesAppDbContext _context;
        public NoteRepository(NotesAppDbContext context)
        {
            _context = context;
        }

        public void Add(Note entity)
        {
            _context.Notes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Note entity)
        {
            _context.Notes.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        public Note GetById(int id)
        {
            return _context.Notes.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Note update)
        {
            _context.Notes.Update(update);
            _context.SaveChanges();
        }
    }
}
