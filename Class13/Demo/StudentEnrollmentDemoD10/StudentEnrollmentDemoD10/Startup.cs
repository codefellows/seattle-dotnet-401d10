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
using StudentEnrollmentDemoD10.Data;
using StudentEnrollmentDemoD10.Models.Interfaces;
using StudentEnrollmentDemoD10.Models.Services;

namespace StudentEnrollmentDemoD10
{
    // To use the Package Manager Console for scripting commands, install the following package in the Package Manager Console:
    // Install-Package Microsoft.EntityFrameworkCore.Tools
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // bring in library Microsoft.Extensions.Configuration
        // Set yourself up for Dependency Injection. 
        // we want the configuration to be...configurable from the Program class. 
        public Startup()
        {
            // enable user secrets for a more secure way to protect our "secrets"
            // Conn strings, api keys, etc...
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // it's to hold dependencies. 
            // middlware.
            services.AddMvc();

            // be sure to install Install-Package Microsoft.EntityFrameworkCore.SqlServer on Package manager console for the use of SQL Server
            services.AddDbContext<StudentEnrollmentDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // These are our mappings.
            // everytime you see IStudentManager, please instantiate an instance of Student Service
            services.AddTransient<IStudentManager, StudentService>();
        }

        // connection string: path to your db server where your db lives

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
