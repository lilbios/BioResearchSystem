using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services.Researches;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResearchService : IResearchService
    {
        private readonly IRepositoryResearch repositoryResearch;
        public ResearchService(IRepositoryResearch repositoryResearch)
        {
            this.repositoryResearch = repositoryResearch;
        }

        public Task EditResearch(ResearchDTO researchDto)
        {
            throw new NotImplementedException();
        }

      
        public async Task<ICollection<Research>> GetAllResearches()
        {
            return await repositoryResearch.GetAllAsync();
        }

        public Task GetResearchByTagName(string tagName)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Research>> GetResearches()
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
