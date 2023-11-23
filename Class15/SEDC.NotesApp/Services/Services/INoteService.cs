using InterfaceModels;

namespace Services
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetUserNotes(int userId);
        NoteDto GetNote(int id, int userId);
        void AddNote(NoteDto model);
        void DeleteItem(int id, int userId);
    }
}
