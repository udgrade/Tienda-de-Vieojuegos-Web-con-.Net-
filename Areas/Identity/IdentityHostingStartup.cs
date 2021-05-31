using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineBlazorApp.Data;

[assembly: HostingStartup(typeof(OnlineBlazorApp.Areas.Identity.IdentityHostingStartup))]
namespace OnlineBlazorApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<OnlineBlazorAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SqlDBContext")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<OnlineBlazorAppContext>();
            });

        }
    }
}