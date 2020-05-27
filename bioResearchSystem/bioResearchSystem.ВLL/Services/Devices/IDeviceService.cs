using bioResearchSystem.Models.Entities;
using bioResearchSystem.ВLL.DomainModels.DeviceModule.Biology;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Devices
{
    public interface IDeviceService
    {
        public Task<ICollection<Device>> GetAllDevices();
        public Task<Device> GetDevice(string alias);
        public Task<Device> GetById(Guid id);

        public Task SwitchDevice(bool toggleToken);
        public Task<DnaUnit> StartSequencingProcess();

    }
}
