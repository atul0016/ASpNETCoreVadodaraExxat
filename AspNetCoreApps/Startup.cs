using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Microsoft.EntityFrameworkCore;
using AspNetCoreApps.Models;

namespace AspNetCoreApps
{
    public class Startup
    {
        /// <summary>
        /// IConfiguration, the contract, that provides application configuration information to
        /// the Startup class. All these configurations are written in appsettings.json 
        /// e.g. ConnectionStrings
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// The method for defining required services (congfiguration and Dependencies) in the container
        /// IServiceCollection is used to register services in the container and the lifetime of service types
        /// is managed by the 'ServiceDescriptor' class
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // regiter the ExStudentDbContext in the Container
            services.AddDbContext<ExStudentDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("AppConnString")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        ///  This method represent the current Http Request and all additional objects to be provided
        ///  the Http request e.g. Security, Exception., etc
        ///  IApplicationBuilder: Builds all "middleware"  for current Http Request
        ///  IHostingEnvironment: provided Hosting
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
