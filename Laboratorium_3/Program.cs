using Laboratorium_3.Services.Interfaces;
using Laboratorium_3.Services;
using Laboratorium_3.Models;
using System.Xml.Linq;
using Data;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;


namespace Laboratorium_3
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddTransient<IContactService, EFContactService>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddSingleton<IContactService, MemoryContactService>();
            builder.Services.AddSingleton<IDataTimeProvider, CurrentDateTimeProvider>();
            builder.Services.AddMemoryCache();                        // dodaæ
            builder.Services.AddDefaultIdentity<IdentityUser>()       // dodaæ
            .AddRoles<IdentityRole>()                             //
            .AddEntityFrameworkStores<Data.AppDbContext>();
            builder.Services.AddSession();
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



            app.UseAuthentication();                                 // dodaæ
            app.UseAuthorization();                                  // dodaæ
            app.UseSession();                                        // dodaæ 
            app.MapRazorPages();
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