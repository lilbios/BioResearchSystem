using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
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
        public Task Create(Device value)
        {
            throw new NotImplementedException();
        }

        public Task<Device> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Device value)
        {
            throw new NotImplementedException();
        }

        public Task Update(Device value)
        {
            throw new NotImplementedException();
        }
    }
}
