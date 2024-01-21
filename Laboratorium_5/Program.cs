using Microsoft.EntityFrameworkCore;
using Data;
using SQLitePCL;

namespace Laboratorium_3
{
    public class Program
    {
       
        public static void Main(string[] args)
        s
            SQLitePCL.Batteries.Init();
            
            var builder = WebApplication.CreateBuilder(args);

           void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Skonfiguruj po³¹czenie z baz¹ danych
            optionsBuilder.UseSqlite("DeafultConnection");
            // Mo¿esz zmieniæ 'UseSqlServer' na odpowiedni dostawca dla Twojej bazy danych
        }
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DeafultConnection")));
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}