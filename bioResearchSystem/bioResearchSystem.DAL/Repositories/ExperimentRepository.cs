using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ExperimentRepository:BaseRepository<Experiment>,IRepositoryExperiment
    {
        public ExperimentRepository(BioResearchSystemDbContext dbContext):base(dbContext)
        {

        }

        public Task<IQueryable<Device>> GetAllWithInludeAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetWithIncludeAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
