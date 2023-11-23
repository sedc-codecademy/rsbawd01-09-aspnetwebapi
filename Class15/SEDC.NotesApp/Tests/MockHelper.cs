using DataAccess;
using System.Security.Cryptography;

namespace Tests
{
    public static class MockHelper
    {
        public static IRepository<User> MockUserRepository()
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);
            List<User> users = new List<User>()
            {
                new User(){
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                }
            };
            Mock<IRepository<User>> mockUserRepository = new Mock<IRepository<User>>();

            mockUserRepository.Setup(x => x.GetAll()).Returns(users);

            mockUserRepository.Setup(x => x.Add(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Add(user);
                });

            mockUserRepository.Setup(x => x.Update(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users[users.IndexOf(user)] = user;
                });

            mockUserRepository.Setup(x => x.Delete(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Remove(user);
                });
            return mockUserRepository.Object;
        }
        public static IRepository<Note> MockNoteRepository()
        {
            List<Note> notes = new List<Note>()
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
            Mock<IRepository<Note>> mockNotesRepository = new Mock<IRepository<Note>>();

            mockNotesRepository.Setup(x => x.GetAll()).Returns(notes);

            mockNotesRepository.Setup(x => x.Add(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes.Add(note);
                });

            mockNotesRepository.Setup(x => x.Update(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes[notes.IndexOf(note)] = note;
                });

            mockNotesRepository.Setup(x => x.Delete(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes.Remove(note);
                });
            return mockNotesRepository.Object;
        }
    }
}
