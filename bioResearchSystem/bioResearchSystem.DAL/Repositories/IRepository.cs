using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        public Task Create(T value);
        public Task<T> Get(int id);
        public Task<ICollection<T>> GetAll();
        public Task Update(T value);
        public Task Remove(T value);
        public Task<ICollection<T>> FindByCondition(Expression<Func<T,bool>> expression);
    }
}
