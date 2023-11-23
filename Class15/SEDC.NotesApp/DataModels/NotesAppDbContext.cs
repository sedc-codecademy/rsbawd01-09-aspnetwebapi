using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;

namespace DataModels
{
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions options)
        : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.NoteList)
                .HasForeignKey(x => x.UserId);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes("123456sedc"));
            var hashedPassword = Encoding.ASCII.GetString(md5data);

            modelBuilder.Entity<User>()
                .HasData(
                new User()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                });
            modelBuilder.Entity<Note>()
                .HasData(
                new Note()
                {
                    Id = 1,
                    Text = "Buy Juice",
                    Color = "blue",
                    Tag = 4,
                    UserId = 1
                },
                new Note()
                {
                    Id = 2,
                    Text = "Learn ASP.NET Core WebApi",
                    Color = "orange",
                    Tag = 1,
                    UserId = 1
                }
                );
        }
    }
}
