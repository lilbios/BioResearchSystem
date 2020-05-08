
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Mode;
using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResultRepository : BaseRepository<Result>, IRepositoryResult
    {
        public ResultRepository(BioResearchSystemDbContext dbContext) : base(dbContext)
        {

        }

        public Task<Result> Create(Result result)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Result>> GetAllWithInlude()
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetObjectWithIcnlude(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
