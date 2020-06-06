using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ResultService : IResultService
    {

        private readonly IRepositoryResult repositoryResult;
        private readonly IMapper mapper;
        public ResultService(IRepositoryResult repositoryResult, IMapper _mapper)
        {
            this.repositoryResult = repositoryResult;
            mapper = _mapper;

        }

        public Task AddResult(ResultDTO resultDto)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> GetResultAsync(Guid id)
        {
            return await repositoryResult.GetAsync(id);
        }
    }
}
