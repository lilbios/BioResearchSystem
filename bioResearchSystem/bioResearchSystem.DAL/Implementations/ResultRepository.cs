using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResultRepository : IRepositoryResult
    {
        private readonly BioResearchSystemDbContex dbContext;
        public ResultRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Result value)
        {
            await dbContext.Results.AddAsync(value);
            await dbContext.SaveChangesAsync();
        }


        public async Task<Result> Get(int id)
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

        public async Task Update(Result value)
        {
            dbContext.Entry(value).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
