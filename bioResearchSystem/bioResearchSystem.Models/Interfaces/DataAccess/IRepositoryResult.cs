
using bioResearchSystem.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryResult : IRepository<Result>
    {
        public Task<Result> Create();
        public Task<ICollection<Device>> GetAllWithInlude();
       
    }
}
