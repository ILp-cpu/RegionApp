using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using RegionService.Interfaces;
using RegionService;

namespace RegionApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<RegionService.Interfaces.IUserService, UserService>();
            //services.AddTransient<RegionService.Interfaces.IUserService, UserService>();
            services.AddTransient<IRegionService, RegionService.RegionService>();
            services.AddTransient<IRouteService, RegionService.RouteService>();
            services.Configure<CookiePolicyOptions>(o =>
            {
                o.CheckConsentNeeded = contex => true;
                o.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            //services.AddDbContext<RegionContext.RegionDBContext>(o => o.UseSqlServer($"Data Source=sql05-srv;Initial Catalog=BackUpDB2;Integrated Security=True"));
            services.AddDbContext<RegionContext.BackUpDB2Context>(o => o.UseSqlServer($"Data Source=MSSQL_SERVER_NAME;Initial Catalog=BackUpDB2;Integrated Security=True"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
