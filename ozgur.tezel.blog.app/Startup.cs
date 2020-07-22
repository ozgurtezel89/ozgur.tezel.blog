using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ozgur.tezel.blog.businessLogic.Interfaces;
using ozgur.tezel.blog.businessLogic.Services;
using ozgur.tezel.blog.dataAccess;
using ozgur.tezel.blog.dataAccess.Interfaces;
using ozgur.tezel.blog.dataAccess.Repositories;

namespace ozgur.tezel.blog.app
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
            /* Bind connection string */
            string blogDatabaseConnectionString = 
                Configuration.GetConnectionString("BLOG_DATABASE_CONNECTION_STRING") ?? 
                throw new ArgumentNullException(nameof(blogDatabaseConnectionString));

            /* Register database services  */
            services.AddSingleton<IDatabaseConfigurationProvider>(x
                => new BlogDatabaseConfigurationProvider(blogDatabaseConnectionString))
                .AddTransient<IPostRepository, PostRepository>();

            /* Register Business Logic Services */
            services
                .AddTransient<IPostBusinessLayer, PostBusinessLayer>()
                .AddTransient<IAdminBusinessLayer, AdminBusinessLayer>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Post}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "postDetails",
                    pattern: "{controller=Post}/{action=Details" +
                    "}/{id?}");

                endpoints.MapControllerRoute(
                    name: "adminTotalPosts",
                    pattern: "{controller=Admin}/{action=Home}");

            });
        }
    }
}
