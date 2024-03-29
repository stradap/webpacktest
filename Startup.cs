﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;

namespace webpacktest
{
    public class Startup
    {
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
            {
                HotModuleReplacement = true
            });
        }
        app.UseStaticFiles();
        app.UseMvc(routes => {
            routes.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}"
            );
        });
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World!");
        });
        }
    }
}
