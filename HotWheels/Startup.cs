using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotWheels.Inter;
using HotWheels.Models;
using HotWheels.Repo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HotWheels
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DB>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("HotWheelsConnection")));

            services.AddTransient<ISanPham, RSanPham>();
            services.AddTransient<IThuongHieu, RThuongHieu>();
            services.AddTransient<ITaiKhoan, RTaiKhoan>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => GioHang.LayGioHang(sp));
            services.AddTransient<IDonHang, RDonHang>();

            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapAreaRoute(
                  name: "areaAdmin",
                  areaName: "Admin",
                  template: "{controller=Admin}/{action=Index}/{id?}"
                );
            });
            
        }
    }
}
