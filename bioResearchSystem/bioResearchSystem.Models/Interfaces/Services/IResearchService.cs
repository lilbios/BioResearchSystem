using bioResearchSystem.Models.Entities;
using System;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface IResearchService
    {
        public Task<T> СreateNewResearch(T research);
        public Task RemoveResearch(Guid id);
        public Task EditResearch(T research);
        public Task GetResearchByTagName(Tag tag);
    }
}
