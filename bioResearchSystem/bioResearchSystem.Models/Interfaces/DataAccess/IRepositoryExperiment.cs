
using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryExperiment: IRepository<Experiment>
    {

        public Task<Experiment> GetWithIncludeAsync(Guid id);
        public Task<ICollection<Experiment>> GetAllWithInludeAsync();
    }
}
