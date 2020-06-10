﻿using bioResearchSystem.DAL.Repositories;
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
    public class ExperimentRepository : BaseRepository<Experiment>, IRepositoryExperiment
    {
        public ExperimentRepository(BioResearchSystemDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Experiment> CreateAsync(Experiment experiment)
        {
            await dbSet.AddAsync(experiment);
            await dbContext.SaveChangesAsync();
            return experiment;
        }

        public async Task<ICollection<Experiment>> GetAllWithInludeAsync()
        {
            return await dbSet.Include(r => r.Research).AsNoTracking().ToListAsync();
        }

        public Task<Experiment> GetWithIncludeAsync(Guid id)
        {
            var experiment = dbSet.Include(rsrch => rsrch.Research)
                .Include(res => res.Result)
                .FirstOrDefaultAsync(e => e.Id == id);
            return experiment;
        }
    }
}

