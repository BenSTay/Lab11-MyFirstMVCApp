using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace PersonOfTheYear
{
    public class Startup
    {
        /// <summary>
        /// Tells the program which services to use.
        /// </summary>
        /// <param name="services">A collection of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        /// <summary>
        /// Sets parameters determining the behavior of the application.
        /// </summary>
        /// <param name="app">The application being configured.</param>
        /// <param name="env">The environment the application is running in.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
