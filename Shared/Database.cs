using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;

namespace Configurations
{
    public class Database
    {
        public static void ConfigureMySQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ConfeccionesSATDbContext>(
                (DbContextOptionsBuilder options) =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}
