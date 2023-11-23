using Configurations;
using Dapper;
using Dapper.Contrib.Extensions;
using DataModels;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace DataAccess
{
    public class NoteDapperRepository : IRepository<Note>
    {
        private AppSettings _appSettings;

        public NoteDapperRepository(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }
        public void Delete(Note entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_appSettings.NoteAppConnectionString))
            {
                sqlConnection.Open();

                string sql = "DELETE FROM dbo.Notes WHERE Id = @NoteId";
                sqlConnection.Execute(sql, new { NoteId = entity.Id });
            }
        }

        public IEnumerable<Note> GetAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_appSettings.NoteAppConnectionString))
            {
                sqlConnection.Open();
                List<Note> notesDb = sqlConnection.Query<Note>("SELECT * FROM dbo.Notes").ToList();
                return notesDb;
            }
        }

        public Note GetById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_appSettings.NoteAppConnectionString))
            {
                sqlConnection.Open();

                Note noteDb = sqlConnection.Query<Note>("SELECT * FROM dbo.Notes WHERE Id = @NoteId", new { NoteId = id }).FirstOrDefault();
                return noteDb;
            }
        }

        public void Add(Note entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_appSettings.NoteAppConnectionString))
            {
                sqlConnection.Open();
                string insertQuery = @"INSERT INTO [dbo].[Notes]([Text], [Color], [Tag], [UserId]) VALUES (@Text, @Color, @Tag, @UserId)";

                sqlConnection.Query(insertQuery, new
                {
                    Text = entity.Text,
                    Color = entity.Color,
                    Tag = entity.Tag,
                    UserId = entity.UserId
                });
            }
        }

        public void Update(Note entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_appSettings.NoteAppConnectionString))
            {
                sqlConnection.Open();
                string insertQuery = @"UPDATE [dbo].[Notes] SET Text = @Text, Color = @Color, Tag = @Tag, UserId = @UserId WHERE Id = @Id";

                sqlConnection.Query(insertQuery, new
                {
                    Id = entity.Id,
                    Text = entity.Text,
                    Color = entity.Color,
                    Tag = entity.Tag,
                    UserId = entity.UserId
                });
            }
        }
    }
}
