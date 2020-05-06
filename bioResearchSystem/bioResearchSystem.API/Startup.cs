using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace bioResearchSystem.API
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

            //Used for connection for database
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddControllers();
            services.AddDbContext<BioResearchSystemDbContex>(options => options.UseSqlServer(connection,
                assembly => assembly.MigrationsAssembly(nameof(Context))));

            services.AddControllersWithViews();

            //DI approach
            services.AddTransient<IRepositoryDevice,DeviceRepository>();
            services.AddTransient<IRepositoryExperiment, ExperimentRepository>();
            services.AddTransient<IRepositoryObjective, ObjectiveRepository>();
            services.AddTransient<IRepositoryResearch, ResearchRepository>();
            services.AddTransient<IRepositoryResult, ResultRepository>();
            services.AddTransient<IRepositoryTopic, TopicRepository>();
            services.AddTransient<IRepositoryUser, UserRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

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
