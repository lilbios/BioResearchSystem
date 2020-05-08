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
    public class ResearchRepository:BaseRepository<Research>,IRepositoryResearch
    {
        public ResearchRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        {

        }

        public Task<Research> CreateResearch(Research research)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetAllWithInlude()
        {
            throw new NotImplementedException();
        }

        public Task GetWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
