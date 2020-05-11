using bioResearchSystem.Models;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly BioResearchSystemDbContext dbContext;
        protected readonly DbSet<T> dbSet;
        public BaseRepository(BioResearchSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }
        public async Task AddAsync(T item)
        {
            await dbSet.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public async  Task<T> GetAsync(Guid id)
        {
            var item = await dbSet.FindAsync(id);
            return item;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async  Task RemoveAsync(T item)
        {
            dbSet.Remove(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T value)
        {
            dbSet.Update(value);
           await dbContext.SaveChangesAsync();
        }

        
    }
}
