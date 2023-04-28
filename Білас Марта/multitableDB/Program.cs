using ClientWebAPI.Infrastructure;
using multitableDataBase.Services;
using multitableDataBase.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add connection tp mySQl database
builder.Services.AddTransient(_ => new AppDb(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFake,Fake>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
