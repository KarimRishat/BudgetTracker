using Tracker.Models;

namespace Tracker.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<LocalUser> Register(RegistrationRequest registrationRequest);
    }
}
