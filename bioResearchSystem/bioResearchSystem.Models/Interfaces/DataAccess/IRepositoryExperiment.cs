
using bioResearchSystem.Models.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryExperiment: IRepository<Experiment>
    {

        public Task GetWithIncludeAsync(Guid id);
        public Task<IQueryable<Device>> GetAllWithInludeAsync();
    }
}
