using bioResearchSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryUser
    {
        public Task CreateAsync(User value);
        public Task<User> GetAsync(string id);
        public  Task<ICollection<User>> GetAllAsync();
        public  Task RemoveAsync(User value);
        public  Task UpdateAsync(User user);
    }
}
