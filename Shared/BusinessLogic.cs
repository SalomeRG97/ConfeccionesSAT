using Interfaces.Repository.Base;
using Interfaces.Repository.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Repository.Base;
using Interfaces.Service;
using Services;
using Repository.Repositories;


namespace Configurations
{
    public class BusinessLogic
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IInputRepository, InputRepository>();
            builder.Services.AddScoped<IMachineRepository, MachineRepository>();
            builder.Services.AddScoped<IInventoryMovementsRepository, InventoryMovementsRepository>();
        }
        public static void Services(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IInputService, InputService>();
            builder.Services.AddScoped<IMachineService, MachineService>();
            builder.Services.AddScoped<IInventoryMovementsService, InventoryMovementsService>();
        }
    }
}
