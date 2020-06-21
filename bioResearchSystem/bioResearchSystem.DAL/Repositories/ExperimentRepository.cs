using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ExperimentRepository : BaseRepository<Experimet>, IRepositoryExperiment
    {
        public ExperimentRepository(BioResearchSystemDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Experimet> CreateAsync(Experimet experiment)
        {
            await dbSet.AddAsync(experiment);
            await dbContext.SaveChangesAsync();
            return experiment;
        }

        public async Task<ICollection<Experimet>> GetAllWithInludeAsync()
        {
            return await dbSet.Include(r => r.Research).AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<Experimet>> GetUsersExperiments(string id)
        {
            var experiments =  await Task.Run(()=> dbContext.Contracts.Where(u=> u.UserId == id).Select(a => a.Research.Experiments));
            return experiments as ICollection<Experimet>;
        }

        public Task<Experimet> GetWithIncludeAsync(Guid id)
        {
            var experiment = dbSet.Include(rsrch => rsrch.Research)
                .FirstOrDefaultAsync(e => e.Id == id);
            return experiment;
        }
    }
}

