using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models;
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
        public  async Task<ICollection<Device>> GetAllWithInludeAsync()
        {
            return await dbSet.Include(u => u.User).AsNoTracking().ToListAsync();
        }

        public async Task<Device> GetWithIncludeAsync(Guid id)
        {
            var device = await dbSet.Include(u => u.User).FirstOrDefaultAsync(d => d.Id == id);
            return device;
        }
    }
}
