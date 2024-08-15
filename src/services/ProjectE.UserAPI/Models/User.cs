using ProjectE.UserAPI.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace ProjectE.UserAPI.Models
{
    public class User : IdentityUser<long>
    {
        public Cpf Cpf { get; set; } = null!; 
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
