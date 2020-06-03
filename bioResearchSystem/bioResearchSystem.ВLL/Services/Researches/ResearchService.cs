using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services.Researches;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResearchService : IResearchService
    {

        private readonly IMapper mapper;
        private readonly IRepositoryResearch researchRepository;
        public ResearchService(IMapper _mapper, IRepositoryResearch researchRepository)
        {
           
            mapper = _mapper;
            this.researchRepository = researchRepository;

        }

        public Task EditResearch(ResearchDTO researchDto)
        {
            throw new NotImplementedException();
        }


        public async Task<ICollection<Research>> GetAllResearches()
        {
            return await researchRepository.GetAllAsync();
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

        public async Task<Research> СreateNewResearch(ResearchDTO researchDto)
        {
            var research = mapper.Map<Research>(researchDto);
            return await researchRepository.CreateResearch(research);
        }
    }
}
