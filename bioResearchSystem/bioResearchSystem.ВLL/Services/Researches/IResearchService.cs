using bioResearchSystem.Models.Entities;
using bioResearchSystem.ВLL.Services.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Researches
{
    public interface IResearchService
    {
        public Task<Research> СreateNewResearch(ResearchDTO researchDto);
        public Task RemoveResearch(Guid id);
        public Task EditResearch(ResearchDTO researchDto);
        public Task GetResearchByTagName(string tagName);
        public Task<ICollection<Research>> FindResearchsRelatedWithTag(Tag tag);
    } 
}
