namespace BookStoreMVCAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configure the project to behave as an ASP.NET Core MVC Project
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //Middleware for MVC 

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "booksroute",
                    pattern: "{controller=Books1}/{action=Index}/{id?}");

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