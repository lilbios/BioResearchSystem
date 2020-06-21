
using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryExperiment: IRepository<Experimet>
    {

        public Task<Experimet> GetWithIncludeAsync(Guid id);
        public Task<ICollection<Experimet>> GetAllWithInludeAsync();
        public Task<Experimet> CreateAsync(Experimet experiment);
        public Task<ICollection<Experimet>> GetUsersExperiments(string id);
    }
}
