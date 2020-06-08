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
        public Task<ICollection<Research>> GetAllResearches();
        public Task<ICollection<Research>> GetResearches();
        public Task JoinToResearch(string userId, Guid researchId);
        public Task LeaveResearch(string userId, Guid researchId);
        public Task<ICollection<Research>> GetChunckedResearchCollection(int page,int pageSize);
        public Task<int> ResearchCollectionLength();
        public Task<Research> GetResearchAsync(Guid id);
    } 
}
