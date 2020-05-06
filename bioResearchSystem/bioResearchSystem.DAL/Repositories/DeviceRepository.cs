using bioResearchSystem.Context;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class DeviceRepository : IRepositoryDevice
    {
        private readonly BioResearchSystemDbContext dbContext;
        public DeviceRepository(BioResearchSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task Create(Device value)
        {
            await dbContext.Devices.AddAsync(value);
            await dbContext.SaveChangesAsync();
        }


        public async Task<Device> Get(Guid id)
        {
            var device = await dbContext.Devices
                .Include(u => u.User).FirstOrDefaultAsync(d => d.Id == id);
            return device;
        }

        public async Task<ICollection<Device>> GetAll()
        {
            var devices = await dbContext.Devices.Include(u => u.User).ToListAsync();
            return devices;
        }

        public async Task Remove(Device value)
        {
            var device = await Get(value.Id);
            if (device != null)
            {
                dbContext.Devices.Remove(device);
                await dbContext.SaveChangesAsync();
            }
        }
        
        public async Task Update(Device device)
        {
            dbContext.Entry(device).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
