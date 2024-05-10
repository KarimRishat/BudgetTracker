using Tracker.Models;

namespace Tracker.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _db.LocalUsers.FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginRequest> Login(LoginRequest loginRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalUser> Register(RegistrationRequest registrationRequest)
        {
            LocalUser user = new LocalUser()
            {
                UserName = registrationRequest.UserName,
                Password = registrationRequest.Password,
                Name = registrationRequest.Name,
                Role = registrationRequest.Role,
            };
            _db.LocalUsers.Add(user);
            _db.SaveChanges();
            user.Password = "";
            return user;
        }
    }
}
