using Microsoft.EntityFrameworkCore;

//namespace Asp_Project
//{
//    class Program
//    {
//        public void Main(string[] args) 
//        {

//            var builder = WebApplication.CreateBuilder(args);
//            var app = builder.Build();

//            app.MapGet("/", () => "Hello World!");

//            app.Run();

//        }
//    }
//}

var path = WebApplication.CreateBuilder(args);
var app = path.Build();

app.MapGet("/Hello", () => "Hello World!");

app.Run();