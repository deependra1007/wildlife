using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wildlife.Areas.Identity.Data;
using wildlife.Data;
using DbContext = wildlife.Data.DbContext;

[assembly: HostingStartup(typeof(wildlife.Areas.Identity.IdentityHostingStartup))]
namespace wildlife.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DbContextConnection")));

                services.AddDefaultIdentity<wildlifeUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DbContext>();


                //builder.ConfigureServices((context, services) => {
                //    services.AddDbContext<UsingIdentityContext>(options =>
                //        options.UseSqlServer(
                //            context.Configuration.GetConnectionString("UsingIdentityContextConnection")));

                //    services.AddDefaultIdentity<UsingIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                //        .AddEntityFrameworkStores<UsingIdentityContext>();
                //});
            });
        }
    }
}