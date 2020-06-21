using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services.Experiments;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ExperimentService : IExperimentService
    {

        private readonly IMapper mapper;
        private readonly IRepositoryExperiment repositoryExperiment;
        private readonly IRepositoryResearch repositoryResearch;
        public ExperimentService(IMapper _mapper,
            IRepositoryExperiment repositoryExperiment,
            IRepositoryResearch repositoryResearch)
        {
            this.repositoryExperiment = repositoryExperiment;
            this.repositoryResearch = repositoryResearch;

            mapper = _mapper;

        }

        public async Task<Experimet> CreateNewExperiment(Experimet experiment)
        {
            return await repositoryExperiment.CreateAsync(experiment);
        }

        public async  Task<Experimet> GetExperimentAsync(Guid id)
        {
            return await repositoryExperiment.GetAsync(id);
        }

        public async Task<ICollection<Experimet>> GetUsersExperiments(string id)
        {
            var experiments = await repositoryExperiment.GetUsersExperiments(id);
            return experiments;
        }

        public Task RemoveExperiment(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Experimet> UpdateExperimentWithResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdeteExperiment(Experimet experiment)
        {
            await repositoryExperiment.UpdateAsync(experiment);
        }


    }
}
