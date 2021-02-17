using Microsoft.AspNetCore.Identity;

namespace Commander.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Role { get; set; }
    }
}