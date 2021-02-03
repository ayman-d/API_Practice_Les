using Microsoft.AspNetCore.Identity;

namespace Commander.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}