using Configurations;

var builder = WebApplication.CreateBuilder(args);

Automapper.ConfigureService(builder);
BusinessLogic.RepositoryService(builder);
BusinessLogic.Services(builder);
Configuration.ConfigureServices(builder);
Database.ConfigureMySQLService(builder);

var app = builder.Build();

Configuration.ConfigureApp(app);

