using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UIPages.Data;

[assembly: HostingStartup(typeof(UIPages.Areas.Identity.IdentityHostingStartup))]
namespace UIPages.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<UIPagesContextTest>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("UIPagesContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<UIPagesContextTest>();
            //});
        }
    }
}