using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApp.Models;
using WebApp.Services;

namespace WebApp
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
            services.AddControllersWithViews();

            // Dependency Injection is a design pattern to achieve "IoC" / decoupling
            // between classes and their dependencies.

            // Dependency is an object that another object requires. ~ are problematic:
            // - Implementation replacement requires modification.
            // - Configuration of dependency tree.
            // - Difficult or impossible to unit test.

            // Dependency injection addresses these problems through:
            // - The use of an interface or base class to abstract the dependency implementation.
            // - Registration of the dependency in a service container. 
            //   ASP.NET Core provides a built-in service container: IServiceProvider.
            // - Injection of the service into the constructor of the class where it's used. 
            //   The framework takes on the responsibility of creating an instance of the dependency and disposing of it when it's no longer needed.

            // Lifetime
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.Empty));

            services.AddTransient<OperationService, OperationService>();

            // WARN: Automatic object disposal only if instantiation is handled by the framework
            // The container calls Dispose for the IDisposable types it creates. 
            // If an instance is added to the container by user code, it isn't disposed automatically.
            // services.AddScoped(sp => new OperationService());
            // services.AddScoped(new OperationService());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from this awesome app!");
            });

            app.UseLogRequest();

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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
