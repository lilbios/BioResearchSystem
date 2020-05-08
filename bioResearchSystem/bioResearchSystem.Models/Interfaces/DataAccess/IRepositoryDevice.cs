
using bioResearchSystem.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Repositories
{
    public interface IRepositoryDevice: IRepository<Device>
    {
        public Task<Device> GetWithIncludeAsync(Guid id);
        public Task<ICollection<Device>> GetAllWithInludeAsync();
    }
}
