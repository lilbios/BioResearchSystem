
using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryObjective: IRepository<Objective>
    {
        public Task GetWithIncludeAsync(Guid id,Guid researchGuid);
        public Task<ICollection<Device>> GetAllWithInludeAsync();
        public Task<Objective> CreateObjective(Objective objective);
        
    }
}
