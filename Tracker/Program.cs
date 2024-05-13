using Microsoft.EntityFrameworkCore;
using Tracker.Models;
using Microsoft.AspNetCore.Identity;

namespace Tracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense
                ("Mgo+DSMBMAY9C3t2UFhhQlJBfVpdXGZWfFN0QXNcdV9yflFPcDwsT3RfQFljTX9Wd0JiX35feXBUTg==");


            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

            builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Dashboard}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
