using DataAccess;
using System.Security.Cryptography;

namespace Tests
{
    public class FakeUserRepository : IRepository<User>
    {
        private List<User> users;
        public FakeUserRepository()
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            users = new List<User>()
            {
                new User(){
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                }
            };
        }
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Delete(User entity)
        {
            users.Remove(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.SingleOrDefault(x => x.Id == id);
        }

        public void Update(User update)
        {
            users[users.IndexOf(update)] = update;
        }
    }
    public class FakeNoteRepository : IRepository<Note>
    {
        private List<Note> notes;
        public FakeNoteRepository()
        {
            notes = new List<Note>()
            {
                new Note(){
                    Id = 1,
                    Text = "Don't forget to water the plant",
                    Color = "blue",
                    Tag = 2,
                    UserId = 1
                },
                new Note(){
                    Id = 2,
                    Text = "Drink more Tea",
                    Color = "yellow",
                    Tag = 3,
                    UserId = 1
                }
            };
        }
        public void Add(Note entity)
        {
            notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            notes.Remove(entity);
        }

        public IEnumerable<Note> GetAll()
        {
            return notes;
        }

        public Note GetById(int id)
        {
            return notes.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Note update)
        {
            notes[notes.IndexOf(update)] = update;
        }
    }
}
