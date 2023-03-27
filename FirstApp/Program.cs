using Microsoft.Extensions.FileProviders;
using System.Reflection.Metadata.Ecma335;

namespace FirstApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var config = builder.Configuration;            


            //Middleware 
            //app.UseRouting();
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "demo")),
                RequestPath= new PathString("/demo")
            });
          

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/showmessage", () => "Hello User, Welcome to Asp.Net Core");

            app.MapGet("/showtime",()=> { return DateTime.Now.ToString(); });

            app.MapGet("/message", () => { return config["message"]; });

            app.Run();
        }
    }
}