namespace Tracker.Models
{
    //аутентификация пользователя
    public class LoginResponse
    {
        public LocalUser User { get; set; }
        public string Token { get; set; }
    }
}
