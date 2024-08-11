using Microsoft.EntityFrameworkCore;
using OrderProject.Infra;

namespace OrderProject.API.Middlewares
{
    public static class Configuration
    {
        public static void ResolveDependecies(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<OrderDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        } 
    }
}
