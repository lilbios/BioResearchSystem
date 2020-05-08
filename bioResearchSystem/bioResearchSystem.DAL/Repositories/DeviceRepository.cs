using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class DeviceRepository : BaseRepository<Device>, IRepositoryDevice
    {
        public DeviceRepository(BioResearchSystemDbContext dbContext):base(dbContext)
        {

        }
        public Task<ICollection<Device>> GetAllWithInludeAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetWithIncludeAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
