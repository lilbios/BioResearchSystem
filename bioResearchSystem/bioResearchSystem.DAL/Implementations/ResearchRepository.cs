using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResearchRepository:IRepositoryResearch
    {
        private readonly BioResearchSystemDbContex dbContext;
        public ResearchRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Research value)
        {
            dbContext.Researches.Add(value);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Research> Get(int id)
        {
            var research = await dbContext.Researches
                .Include(o => o.Objectives)
                .Include(e => e.Experiment)
                .FirstOrDefaultAsync(r => r.Id == id);
            return research;
        }

        public async Task<ICollection<Research>> GetAll()
        {
            var researches = await dbContext.Researches
                .Include(o => o.Objectives)
                .Include(e => e.Experiment)
                .ToListAsync();
            return researches;
        }

        public async Task Remove(Research value)
        {
            var research = await Get(value.Id);
            if (research != null) {

                dbContext.Researches.Remove(value);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(Research value)
        {
            dbContext.Entry(value).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
