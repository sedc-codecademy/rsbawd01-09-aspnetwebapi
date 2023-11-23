namespace InterfaceModels
{
    public class UserDto
    {
        public UserDto()
        {
            NoteList = new List<NoteDto>();
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Token { get; set; }
        public List<NoteDto> NoteList { get; set; }
    }
}
