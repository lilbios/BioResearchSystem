
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Mode;
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
    public class ObjectiveRepository:BaseRepository<Objective>,IRepositoryObjective
    {
        public ObjectiveRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        { }
        

        public  async  Task<Objective> CreateObjective(Objective objective)
        {
            await dbSet.AddAsync(objective);
            await dbContext.SaveChangesAsync();
            return objective;

        }

        public async Task<ICollection<Objective>> GetAllWithInludeAsync(Guid researchId)
        {
            return await dbSet.Include(r => r.Research).Where(o => o.ResearchId == researchId)
                .AsNoTracking().ToListAsync();
        }

        public async Task<Objective> GetWithIncludeAsync(Guid id, Guid researchId)
        {
            var objective = await dbSet.Include(r => r.Research)
                .FirstOrDefaultAsync(o => o.Id == id && o.ResearchId == researchId);
            return objective;
        }
    }
}
