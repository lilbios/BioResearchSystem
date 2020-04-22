using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class DeviceRepository : IRepositoryDevice
    {
        private readonly BioResearchSystemDbContex dbContext;
        public DeviceRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task Create(Device value)
        {
            dbContext.Devices.Add(value);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Device> Get(int id)
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
        
        public async Task Update(Device value)
        {
            dbContext.Entry(value).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
