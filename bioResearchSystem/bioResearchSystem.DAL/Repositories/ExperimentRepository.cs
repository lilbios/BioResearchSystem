using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ExperimentRepository:IRepositoryExperiment
    {
        private readonly BioResearchSystemDbContext dbContext;
        public ExperimentRepository(BioResearchSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Experiment value)
        {
            await dbContext.Experiments.AddAsync(value);
            await dbContext.SaveChangesAsync();
        }


        public async Task<Experiment> Get(Guid id)
        {
            var experiment = await dbContext.Experiments
                .Include(results => results.Results).Include(reseaches => reseaches.Researches)
                .FirstOrDefaultAsync(e => e.Id == id);
            return experiment;
        }

        public async Task<ICollection<Experiment>> GetAll()
        {
            var experiments = await dbContext.Experiments
               .Include(results => results.Results).Include(reseaches => reseaches.Researches)
               .ToListAsync();
            return experiments;
        }

        public async Task Remove(Experiment value)
        {
            var  experiment = await Get(value.Id);
            if (experiment != null)
            {
                dbContext.Entry(value).State = EntityState.Deleted;
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(Experiment experiment)
        {
            dbContext.Entry(experiment).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
