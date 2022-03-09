using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BookProject.Models;

namespace BookProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }


        public Startup (IConfiguration temp)
        {
            Configuration = temp;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:WaterDBConnection"]);

           });

            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<ICartRepository, EFCartRepository>();

            services.AddRazorPages();

            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddScoped<Basket>(x => SessionBasket.Getbasket(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Corresponds to the wwwroot
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {

              
                endpoints.MapControllerRoute("Categorypage", "{Category}/Page{pageNum}", new { Controller = "Home", action = "Index" });
                endpoints.MapControllerRoute("Paging", "Page{pageNum}", new { Controller = "Home", action = "Index", pageNum = 1 });
                endpoints.MapControllerRoute("Category", "{Category}", new { Controller = "Home" , action = "Index", pageNum = 1});





                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
          }
        }
    }

