using ProjectMovie;

var builder = WebApplication.CreateBuilder(args);
ProjectConfig.ConfigureServices(builder);

var app = builder.Build();
ProjectConfig.SeedDatabase(app);
ProjectConfig.ConigureMiddleware(app);

await app.RunAsync();
