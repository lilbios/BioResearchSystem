using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Experiments
{
    public interface IExperimentService
    {
        public Task<Experiment> CreateNewExperiment(Experiment experiment);
        public Task<Experiment> UpdateExperimentWithResult(Guid id);
        public Task RemoveExperiment(Guid id);
        public Task UpdeteExperiment(Experiment experiment);
        public Task<Experiment> GetExperimentAsync(Guid id);
    }
}
