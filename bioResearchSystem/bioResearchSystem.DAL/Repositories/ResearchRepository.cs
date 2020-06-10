
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
    public class ResearchRepository : BaseRepository<Research>, IRepositoryResearch
    {
        public ResearchRepository(BioResearchSystemDbContext dbContext) : base(dbContext)
        {

        }



        public async Task<Research> CreateResearch(Research research)
        {
            await dbSet.AddAsync(research);
            await dbContext.SaveChangesAsync();
            return research;
        }

        public async Task<ICollection<Research>> FindRelatedWithTag(string tagName)
        {
            var tag = await dbContext.TagResearches.FirstOrDefaultAsync(tr => tr.Tag.TagName == tagName);
            var resultCollection = new List<Research>();
            var dbCollection = await dbSet.Include(e => e.Experiments)
                .Include(o => o.Objectives)
                .Include(u => u.AppUser)
                .Include(c => c.Contracts)
                .Include(tr => tr.TagResearches).ThenInclude(t => t.Tag)
                .ToListAsync(); ;


            foreach (var research in dbCollection)
            {
                foreach (var tagResearch in research.TagResearches)
                {
                    if (tag.Tag.TagName == tagResearch.Tag.TagName)
                    {
                        resultCollection.Add(research);
                    }
                }
            }
            return resultCollection;





        }

        public async Task<ICollection<Research>> GetAllWithInlude()
        {
            return await dbSet.Include(e => e.Experiments)
                .Include(o => o.Objectives)
                .Include(u => u.AppUser)
                .Include(c => c.Contracts)
                .Include(tr => tr.TagResearches).ThenInclude(t => t.Tag)
                .ToListAsync();
        }

        public Task<int> GetResearchCollectionLength() => Task.Run(() => dbSet.Count());

        public async Task<Research> GetWithInclude(Guid id)
        {
            return await dbSet.Include(e => e.Experiments)
                .Include(o => o.Objectives)
                .Include(u => u.AppUser)
                .Include(c => c.Contracts)
                .Include(tr => tr.TagResearches).ThenInclude(t => t.Tag).FirstOrDefaultAsync(r => r.Id == id);


        }

        public async Task<ICollection<Research>> SliceResearchCollection(int currentPage, int pageSize)
        {
            var collection = await dbSet.Include(e => e.Experiments)
                 .Include(o => o.Objectives)
                 .Include(u => u.AppUser)
                 .Include(c => c.Contracts)
                 .Include(tr => tr.TagResearches)
                 .Skip((currentPage - 1) * pageSize).Take(pageSize)
                 .ToListAsync();
            return collection;
        }
    }
}
