using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vehicle_Ownership_MVC.Models;

[assembly: HostingStartup(typeof(Vehicle_Ownership_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Vehicle_Ownership_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Vehicle_Ownership_MVCIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Vehicle_Ownership_MVCIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Vehicle_Ownership_MVCIdentityContext>();
            });
        }
    }
}