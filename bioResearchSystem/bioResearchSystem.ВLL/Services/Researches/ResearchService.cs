using bioResearchSystem.Models.Entities;
using bioResearchSystem.ВLL.Services.Researches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResearchService : IResearchService
    {
        public Task EditResearch(ResearchDTO researchDto)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Research>> FindResearchsRelatedWithTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task GetResearchByTagName(string tagName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveResearch(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Research> СreateNewResearch(ResearchDTO researchDto)
        {
            throw new NotImplementedException();
        }
    }
}
