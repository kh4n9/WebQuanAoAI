using Microsoft.AspNetCore.Identity;

namespace WebQuanAoAI.Models
{
    public class AppUserModel : IdentityUser
    {
        public string Occupasion { get; set; }
    }
}
