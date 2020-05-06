﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ObjectiveRepository : IRepositoryObjective
    {
        private readonly BioResearchSystemDbContext dbContext;
        public ObjectiveRepository(BioResearchSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Objective value)
        {
            await dbContext.Objectives.AddAsync(value);
            await dbContext.SaveChangesAsync();
        }


        public async Task<Objective> Get(Guid id)
        {
            var objective = await dbContext.Objectives
                .Include(r => r.Research)
                .FirstOrDefaultAsync(o => o.Id == id);
            return objective;
        }

        public async Task<ICollection<Objective>> GetAll()
        {
            var objectives = await dbContext.Objectives
                .Include(r => r.Research)
                .ToListAsync();
            return objectives;
        }

        public async Task Remove(Objective value)
        {
            var objective = await Get(value.Id);
            if (objective != null)
            {
                dbContext.Objectives.Remove(objective);
                await dbContext.SaveChangesAsync();
            }
        }

        public async  Task Update(Objective objective)
        {
            dbContext.Entry(objective).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
