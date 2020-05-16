using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ResearchService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;

        }
      
        public Task EditResearch(ResearchDTO researchDto)
        {
            throw new NotImplementedException();
        }

      
        public async Task<ICollection<Research>> GetAllResearches()
        {
            return await unitOfWork.Researches.GetAllAsync();
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
