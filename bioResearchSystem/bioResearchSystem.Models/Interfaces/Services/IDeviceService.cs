using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface IDeviceService<T> where T:class
    {
        public Task<ICollection<T>> GetAllDevices();
        public Task<T> GetDevice(string alias);
        public Task<T> GetById(Guid id);
        public Task<string> GenerateData();
    }
}
