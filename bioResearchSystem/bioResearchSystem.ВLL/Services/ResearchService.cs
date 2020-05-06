using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResearchService : IResearchService
    {
        public Task RemoveResearch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Research> СreateNewResearch(ResearchDTO research)
        {
            throw new NotImplementedException();
        }
    }
}
