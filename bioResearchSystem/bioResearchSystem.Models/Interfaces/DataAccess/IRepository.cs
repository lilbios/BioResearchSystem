using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepository<T> where T:class
    {
        public Task AddAsync(T item);
        public Task<T> GetAsync(Guid id);
        public Task<ICollection<T>> GetAllAsync();
        public Task UpdateAsync(T item);
        public Task RemoveAsync(T item);
        public Task <T> Find(Expression<Func<T, bool>> expression);
       
    }
}
