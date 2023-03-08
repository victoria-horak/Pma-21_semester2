var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Hello World", () => "Hello World!");
app.MapGet("/", () => "");

app.Run();