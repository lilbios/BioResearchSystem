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
    public class ObjectiveRepository:BaseRepository<Objective>,IRepositoryObjective
    {
        public ObjectiveRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        {

        }

        public Task<Objective> CreateObjective(Objective objective)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetAllWithInludeAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetWithIncludeAsync(Guid id, Guid researchGuid)
        {
            throw new NotImplementedException();
        }
    }
}
