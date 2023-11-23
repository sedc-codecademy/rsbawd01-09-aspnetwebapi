using InterfaceModels;

namespace Services
{
    public interface IUserService
    {
        UserDto Authenticate(string username, string password);
        void Register(RegisterDto model);
    }
}
