using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResultService : IResultService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ResultService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;

        }

        public Task AddResult(ResultDTO resultDto)
        {
            throw new NotImplementedException();
        }
    }
}
