
using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryObjective: IRepository<Objective>
    {
        public Task<Objective> GetWithIncludeAsync(Guid id,Guid researchGuid);
        public Task<ICollection<Objective>> GetAllWithInludeAsync(Guid id);
        public Task<Objective> CreateObjective(Objective objective);
        
    }
}
