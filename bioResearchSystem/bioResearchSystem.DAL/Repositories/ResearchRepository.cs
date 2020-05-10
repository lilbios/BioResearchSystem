
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Mode;
using bioResearchSystem.Models;
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

        public async Task<Research> CreateResearch(Research research)
        {
            await dbSet.AddAsync(research);
            await dbContext.SaveChangesAsync();
            return research;
        }

        public  async Task<ICollection<Research>> GetAllWithInlude()
        {
            return await dbSet.Include(e => e.Experiment)
                .Include(o => o.Objectives)
                .Include(u => u.User)
                .Include(tr => tr.TagResearches).ThenInclude(t => t.Tag).AsNoTracking()
                .ToListAsync();
        }

        public Task<Research> GetWithInclude(Guid id)
        {
            throw new NotImplementedException();
        }
        
    }
}
