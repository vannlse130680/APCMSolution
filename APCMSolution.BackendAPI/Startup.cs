using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APCMSolution.Application.Catalog.Brands;
using APCMSolution.Data.EF;
using APCMSolution.Data.Models;
using APCMSolution.Data.Repositories;
using APCMSolution.Data.UnitOfWorks;
using APCMSolution.Utilities.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace APCMSolution.BackendAPI
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
            //copy code edit cai nay 
            services.AddDbContext<CapstoneProjectContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(SystemConstant.MainConnectionString)));
            // Khai bao DI
            services.AddTransient<IRepository<Brand>, Repository<Brand>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IBrandService, BrandService>(); // moi lan request se tao moi

            services.AddControllersWithViews();
            //call method configure swagger
            ConfigureSwagger(services);
        }

        //Swagger config
        private static void ConfigureSwagger(IServiceCollection services)
        {


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Swagger APCM Solution",

                });


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //use swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger APCM Solution V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}