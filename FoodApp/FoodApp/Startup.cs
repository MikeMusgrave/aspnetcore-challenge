using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using FoodApp.Models;

namespace FoodApp
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env) 
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // setup dependecy injection, read cn string from json
            services.AddDbContext<FoodDbContext>(options => options.UseSqlServer(Configuration["Data:FoodAppFoodItems:ConnectionString"]));
            //services.AddTransient<IFoodRepository, FakeFoodRepository>();
            services.AddTransient<IFoodRepository, EFFoodRepository>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseStaticFiles();
                //app.UseBrowserLink();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Food/Error");
            //}

            //app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Food}/{action=List}/{id?}");
            });

            // ensure that there is data in the database
            SeedData.EnsurePopulated(app);
        }
    }
}
