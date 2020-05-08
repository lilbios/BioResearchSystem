using bioResearchSystem.Models.Entities;
using bioResearchSystem.ВLL.Services.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class DeviceService : IDeviceService
    {
        public Task<string> GenerateData()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetDevice(string alias)
        {
            throw new NotImplementedException();
        }
    }
}
