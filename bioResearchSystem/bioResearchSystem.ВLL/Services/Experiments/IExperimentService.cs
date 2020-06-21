using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Experiments
{
    public interface IExperimentService
    {
        public Task<Experimet> CreateNewExperiment(Experimet experiment);
        public Task<Experimet> UpdateExperimentWithResult(Guid id);
        public Task RemoveExperiment(Guid id);
        public Task UpdeteExperiment(Experimet experiment);
        public Task<Experimet> GetExperimentAsync(Guid id);
        public Task<ICollection<Experimet>> GetUsersExperiments(string id);
    }
}
