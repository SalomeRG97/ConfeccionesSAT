using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Interfaces.Repository.Base;
using Repository.Base;

namespace Configurations
{
    public class Configuration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            //Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
        }
        public static void ConfigureApp(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
