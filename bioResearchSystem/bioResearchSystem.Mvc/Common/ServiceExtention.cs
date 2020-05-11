using AutoMapper.Configuration;
using bioResearchSystem.DAL.Implementations;
using bioResearchSystem.Models.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace bioResearchSystem.Mvc.Common
{
    public  static class ServiceExtention
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            services.AddTransient<IRepositoryDevice, DeviceRepository>();
            services.AddTransient<IRepositoryExperiment, ExperimentRepository>();
            services.AddTransient<IRepositoryObjective, ObjectiveRepository>();
            services.AddTransient<IRepositoryResearch, ResearchRepository>();
            services.AddTransient<IRepositoryResult, ResultRepository>();
            services.AddTransient<IRepositoryTopic, TopicRepository>();
            services.AddTransient<IRepositoryUser, UserRepository>();

            return services;

        }
    }
}
