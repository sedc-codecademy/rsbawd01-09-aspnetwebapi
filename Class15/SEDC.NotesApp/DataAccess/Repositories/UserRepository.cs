using DataModels;

namespace DataAccess
{
    public class UserRepository : IRepository<User>
    {
        private readonly NotesAppDbContext _context;
        public UserRepository(NotesAppDbContext context)
        {
            _context = context;
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }

        public void Update(User update)
        {
            _context.Users.Update(update);
            _context.SaveChanges();
        }
    }
}
