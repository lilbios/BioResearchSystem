using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Mode;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResultRepository : BaseRepository<Result>, IRepositoryResult
    {
        public ResultRepository(BioResearchSystemDbContext dbContext) : base(dbContext)
        {

        }

        public Task<Result> Create(Result result)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Result>> GetAllWithInlude()
        {
            return await dbSet.Include(e => e.Experiment).AsNoTracking().ToListAsync();
        }

        public async Task<Result> GetObjectWithIcnlude(Guid id)
        {
            return await dbSet.Include(e => e.Experiment).FirstOrDefaultAsync();
        }
    }
}
