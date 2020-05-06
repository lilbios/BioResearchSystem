using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepository<T> where T:class
    {
        public Task Create(T value);
        public Task<T> Get(Guid id);
        public Task<ICollection<T>> GetAll();
        public Task Update(T value);
        public Task Remove(T value);
    }
}
