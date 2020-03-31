using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MVCDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Add our middleware
            // all the libraries that we are going to be using
            // same as going to NuGet and installing the MVC dependency
            // Hey BTW....we are using MVC
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();
            // static files from CSS. Images. CSV Files ( ;) ) 
            // Anything that is not server specific
            app.UseRouting();

            // setup default routing for our MVC application 
            // our default route is Home controller
            // with our Index action as our default method. 
            // our id is "nullable" meaning it may not exist.
            app.UseEndpoints(endpoints =>
            {
                // this will override your Controller route
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync(".NET ROCKS!!");
                //});

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
