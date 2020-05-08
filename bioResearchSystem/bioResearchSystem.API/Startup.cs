using bioResearchSystem.DAL.Implementations;
using bioResearchSystem.Mode;
using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddDbContext<BioResearchSystemDbContext>(options => options.UseSqlServer(connection,
                assembly => assembly.MigrationsAssembly("bioResearchSystem.Models")));

            services.AddControllersWithViews();
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;

            })
            .AddEntityFrameworkStores<BioResearchSystemDbContext>();

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
