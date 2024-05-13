using Microsoft.AspNetCore.Identity;

namespace Tracker.Models
{
    public class TrackerUser : IdentityUser
    {
        public string? Discriminator { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
