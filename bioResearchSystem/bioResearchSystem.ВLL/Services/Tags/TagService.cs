using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public TagService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public Task AddTag(TagDTO tagDto)
        {
            throw new NotImplementedException();
        }

        public Task RetrieveTag(TagDTO tag)
        {
            throw new NotImplementedException();
        }
    }
}
