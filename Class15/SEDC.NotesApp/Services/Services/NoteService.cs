using DataAccess;
using DataModels;
using InterfaceModels;
using Services.Exceptions;

namespace Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<User> userRepository,
            IRepository<Note> noteRepository)
        {
            _userRepository = userRepository;
            _noteRepository = noteRepository;
        }

        public void AddNote(NoteDto model)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Id == model.UserId);

            if (string.IsNullOrEmpty(model.Text))
                throw new NoteException(model.Id, model.UserId,
                    "Text field is required");

            var note = new Note()
            {
                Text = model.Text,
                Color = model.Color,
                Tag = (int)model.Tag,
                UserId = user.Id
            };
            _noteRepository.Add(note);
        }

        public void DeleteItem(int id, int userId)
        {
            var note = _noteRepository.GetAll()
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (note == null)
                throw new NoteException(id, userId, "Note not found");

            _noteRepository.Delete(note);
        }

        public NoteDto GetNote(int id, int userId)
        {
            var note = _noteRepository.GetAll()
                .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (note == null)
                throw new NoteException(id, userId, "Note not found");

            var noteModel = new NoteDto()
            {
                Id = note.Id,
                Color = note.Color,
                Tag = (TagType)note.Tag,
                Text = note.Text,
                UserId = note.UserId
            };
            return noteModel;
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            return _noteRepository.GetAll()
                .Where(x => x.UserId == userId).Select(x =>
                new NoteDto()
                {
                    Id = x.Id,
                    Color = x.Color,
                    Tag = (TagType)x.Tag,
                    Text = x.Text,
                    UserId = x.UserId
                });
        }
    }
}
