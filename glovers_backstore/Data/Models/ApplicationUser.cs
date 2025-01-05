using Microsoft.AspNetCore.Identity;

namespace glovers_backstore.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public int LastName { get; set; }
    }
}
