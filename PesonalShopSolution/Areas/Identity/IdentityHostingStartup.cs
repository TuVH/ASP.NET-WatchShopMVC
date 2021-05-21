using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PesonalShopSolution.Areas.Admin.Data;
using PesonalShopSolution.Areas.Admin.Models;

[assembly: HostingStartup(typeof(PesonalShopSolution.Areas.Identity.IdentityHostingStartup))]
namespace PesonalShopSolution.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}