var builder = WebApplication.CreateBuilder(args);
var startup = new PlatformServices.Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);
app.Run();
