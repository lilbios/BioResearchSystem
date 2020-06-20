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

        public async Task<Experiment> CreateNewExperiment(Experiment experiment)
        {
            return await repositoryExperiment.CreateAsync(experiment);
        }

        public async  Task<Experiment> GetExperimentAsync(Guid id)
        {
            return await repositoryExperiment.GetAsync(id);
        }

        public Task RemoveExperiment(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Experiment> UpdateExperimentWithResult(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdeteExperiment(Experiment experiment)
        {
            await repositoryExperiment.UpdateAsync(experiment);
        }


    }
}
