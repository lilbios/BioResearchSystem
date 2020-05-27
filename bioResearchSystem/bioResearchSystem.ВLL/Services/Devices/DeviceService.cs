using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.DomainModels.DeviceModule;
using bioResearchSystem.ВLL.DomainModels.DeviceModule.Biology;
using bioResearchSystem.ВLL.Services.Devices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IBaseDevice baseDevice;
        private readonly IMapper mapper;

        public DeviceService (IMapper mapper, IBaseDevice baseDevice)
        {
            this.mapper = mapper;
    
            this.baseDevice = baseDevice;
            

        }

        public Task<string> GenerateData()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Device>> GetAllDevices()
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetById(Guid identifier)
        {
            throw new NotImplementedException();
        }

        public Task<Device> GetDevice(string alias)
        {
            throw new NotImplementedException();
        }

        public Task<DnaUnit> StartSequencingProcess()
        {
            throw new NotImplementedException();
        }

        public async Task SwitchDevice(bool toggleToken)
        {
            if (toggleToken)
            {
                await baseDevice.Connect();
            }
            else {
                await baseDevice.Disconect();
            }
        }
    }
}
