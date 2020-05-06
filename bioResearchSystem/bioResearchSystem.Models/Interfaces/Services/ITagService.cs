using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface ITagService
    {
        public Task AddTag();
        public Task RetrieveTag();
        
    }
}
