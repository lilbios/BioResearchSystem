﻿using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ObjectiveRepository : IRepositoryObjective
    {
        private readonly BioResearchSystemDbContex dbContext;
        public ObjectiveRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Objective value)
        {
            dbContext.Objectives.Add(value);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Objective> Get(int id)
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

        public async async Task Update(Objective value)
        {
            dbContext.Entry(value).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
