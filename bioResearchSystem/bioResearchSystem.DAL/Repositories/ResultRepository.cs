using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResultRepository:BaseRepository<Result>,IRepositoryResult
    {
        public ResultRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        {

        }

        public Task<Result> Create()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetAllWithInlude()
        {
            throw new NotImplementedException();
        }
    }
}
