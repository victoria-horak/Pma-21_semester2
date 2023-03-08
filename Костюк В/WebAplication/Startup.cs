using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MyWebApp
{
    public class Startup
    {

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Write '/HelloWorld' to the path!");
                });
                endpoints.MapGet("/HelloWorld", async context =>
                {
                    await context.Response.WriteAsync("Hello, World!");
                });
            });
        }
    }
}
