
using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryResearch: IRepository<Research>
    {
        public Task<Research> GetWithInclude(Guid id);
        public Task<ICollection<Research>> GetAllWithInlude();
        public Task<Research> CreateResearch(Research research);

    }
}
