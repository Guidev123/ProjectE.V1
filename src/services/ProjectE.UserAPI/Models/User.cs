using HealthLife.UserAPI.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace HealthLife.UserAPI.Models
{
    public class User : IdentityUser<long>
    {
        public Cpf Cpf { get; set; } = null!; 
        public List<IdentityRole<long>>? Roles { get; set; }
    }
}
