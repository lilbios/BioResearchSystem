using bioResearchSystem.DAL.Implementations;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services;
using bioResearchSystem.ВLL.Services.Accounts;
using bioResearchSystem.ВLL.Services.Devices;
using bioResearchSystem.ВLL.Services.Experiments;
using bioResearchSystem.ВLL.Services.Objectives;
using bioResearchSystem.ВLL.Services.Researches;
using bioResearchSystem.ВLL.Services.Results;
using bioResearchSystem.ВLL.Services.Tags;
using bioResearchSystem.ВLL.Services.Topics;
using bioResearchSystem.ВLL.Services.Wallets;
using bioResearchSystem.ВLL.Third_part.pic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace bioResearchSystem.Web.Common
{
    public static  class ServiceExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<BaseRepository<AppUser>,UserRepository>();
            services.AddTransient<IRepository<Research>,ResearchRepository>();
            services.AddTransient<IRepository<Objective>,ObjectiveRepository>();
            services.AddTransient<IRepository<Tag>, TagRepository>();
            services.AddTransient<IRepository<Device>, DeviceRepository>();
            services.AddTransient<IRepository<TagResearch>,TagResearchRepository>();
            services.AddTransient<IRepository<Wallet>,WalletRepository>();
            services.AddTransient<IRepository<Result>,ResultRepository>();
            services.AddTransient<IRepository<Topic>, TopicRepository>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddTransient<IResearchService, ResearchService>();
            services.AddTransient<IDeviceService, DeviceService>();
            services.AddTransient<IExperimentService, ExperimentService>();
            services.AddTransient<IObjectiveService, ObjectiveService>();
            services.AddTransient<ITagService, TagService>();
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<IWalletService, WalletService>();
            services.AddTransient<ITopicService, TopicService>();
            services.AddTransient<IImageBuilder, ImageConvertor>();

            return services;
        }
    }
}
