using ProjectMovie;

var builder = WebApplication.CreateBuilder(args);
ProjectConfig.ConfigureServices(builder);

var app = builder.Build();
await ProjectConfig.SeedDatabaseAsync(app);
ProjectConfig.ConigureMiddleware(app);

await app.RunAsync();
