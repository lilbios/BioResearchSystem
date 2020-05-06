using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResultRepository : IRepositoryResult
    {
        private readonly BioResearchSystemDbContext dbContext;
        public ResultRepository(BioResearchSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Result value)
        {
            await dbContext.Results.AddAsync(value);
            await dbContext.SaveChangesAsync();
        }


        public async Task<Result> Get(Guid id)
        {
            var result = await dbContext.Results
                .Include(e => e.Experiment)
                .FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public async Task<ICollection<Result>> GetAll()
        {
            var results = await dbContext.Results
                .Include(e => e.Experiment)
                .ToListAsync();
            return results;
        }

        public async Task Remove(Result value)
        {
            var result = await Get(value.Id);
            if (result != null)
            {
                dbContext.Results.Remove(result);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(Result result)
        {
            dbContext.Entry(result).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
