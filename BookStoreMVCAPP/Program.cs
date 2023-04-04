using BookStoreMVCAPP.Data;
using BookStoreMVCAPP.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStoreMVCAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Configure the project to behave as an ASP.NET Core MVC Project

            builder.Services.AddDbContext<BookStoreContext>
                (
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("bookconn"))
                ); 

            builder.Services.AddControllersWithViews();
            //builder.Services.AddSingleton<IBookRepository, MockBookRepository>();
            //builder.Services.AddScoped<IBookRepository,MockBookRepository>();
            builder.Services.AddTransient<IBookRepository,SQLBookRepository>();
            var app = builder.Build();
            

            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //Development 
            }
            else
            {
                app.UseExceptionHandler("/Error");
                //app.UseStatusCodePages();
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }


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