﻿using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using MVC6OneManBlog.Controllers;

namespace MVC6OneManBlog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Data>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            //app.UseWelcomePage();
            //            app.UseErrorHandler("/Home/Error");
            app.UseBrowserLink();
            app.UseStaticFiles();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
