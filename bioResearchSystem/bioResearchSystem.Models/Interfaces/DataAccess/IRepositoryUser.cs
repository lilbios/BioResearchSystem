using bioResearchSystem.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryUser
    {
        public Task Create(User value);
        public Task<User> Get(string id);
        public  Task<ICollection<User>> GetAll();
        public  Task Remove(User value);
        public  Task Update(User user);
    }
}
