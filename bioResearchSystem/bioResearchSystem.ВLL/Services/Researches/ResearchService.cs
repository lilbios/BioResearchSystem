using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services.Researches;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResearchService : IResearchService
    {

        private readonly IMapper mapper;
        private readonly IRepositoryResearch researchRepository;
        private readonly IRepositoryContract repositoryContract;
        private readonly UserManager<AppUser> userManager;
        public ResearchService(IMapper _mapper, IRepositoryResearch researchRepository,
            IRepositoryContract repositoryContract, UserManager<AppUser> userManager)
        {

            mapper = _mapper;
            this.researchRepository = researchRepository;
            this.repositoryContract = repositoryContract;
            this.userManager = userManager;

        }

        public Task EditResearch(ResearchDTO researchDto)
        {
            throw new NotImplementedException();
        }

        public async  Task<ICollection<Research>> Find(string searchString)
        {
            return await researchRepository.FindResearchByName(searchString.ToLower());
        }

        public async Task<ICollection<Research>> GetAllResearches()
        {
            return await researchRepository.GetAllWithInlude();
        }

        public async Task<ICollection<Research>> GetChunckedResearchCollection(int page, int pageSize)
        {
            return await researchRepository.SliceResearchCollection(page, pageSize);
        }

        public async Task<Research> GetResearchAsync(Guid id)
        {
            return await researchRepository.GetWithInclude(id);
        }

        public async Task<ICollection<Research>> GetResearchByTagName(string tagName)
        {
            return await researchRepository.FindRelatedWithTag(tagName);
        }

        public Task<ICollection<Research>> GetResearches()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsHasContractWithResearch(AppUser appUser, Research research)
        {
            return await  Task.Run(()=>research.Contracts.Any(c => c.UserId == appUser.Id));

        }

        public async Task JoinToResearch(AppUser appUser, Guid researchId)
        {
            var contract = new Contract
            {
                UserId = appUser.Id,
                ResearchId = researchId,
                User = appUser,
                Research = await researchRepository.GetWithInclude(researchId)
            };
            await repositoryContract.AddAsync(contract);
        }

        public Task LeaveResearch(AppUser appUser, Guid researchId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveResearch(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> ResearchCollectionLength() => await researchRepository.GetResearchCollectionLength();

        public async Task<Research> СreateNewResearch(ResearchDTO researchDto)
        {
            var research = mapper.Map<Research>(researchDto);

            return await researchRepository.CreateResearch(research);
        }
    }
}
