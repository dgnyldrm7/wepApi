using Microsoft.AspNetCore.Identity;

namespace wepApi.Models
{
    public class AppRole : IdentityRole<int>
    {
        public string FullName { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}
