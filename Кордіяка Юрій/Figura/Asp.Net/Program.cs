var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/Hello", () => "Hello World!");

app.Run();