using JavaScriptEngineSwitcher.ChakraCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBookApi.Configuration;
using Microsoft.AspNetCore.Http;
using React.AspNet;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;

namespace PhoneBookApi
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
            services.AddMvc();
            services.ConfigureDependencies(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            //Make sure a JS engine is registered, or you will get an error!
            services
                .AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config => { });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
