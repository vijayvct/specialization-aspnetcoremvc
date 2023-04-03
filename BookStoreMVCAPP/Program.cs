using BookStoreMVCAPP.Services;

namespace BookStoreMVCAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configure the project to behave as an ASP.NET Core MVC Project
            builder.Services.AddControllersWithViews();
            //builder.Services.AddSingleton<IBookRepository, MockBookRepository>();
            //builder.Services.AddScoped<IBookRepository,MockBookRepository>();
            builder.Services.AddTransient<IBookRepository,MockBookRepository>();
            var app = builder.Build();

            //Middleware for MVC 
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "booksroute",
                    pattern: "{controller=Books}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //using default route pattern
                //endpoints.MapDefaultControllerRoute();
            });


            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}