
using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryResult : IRepository<Result>
    {
        public Task<Result> Create(Result result);
        public Task<ICollection<Result>> GetAllWithInlude();
        public Task<Result> GetObjectWithIcnlude(Guid id);
        
    }
}
