using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResultRepository:IRepositoryResult
    {
        private readonly BioResearchSystemDbContex dbContext;
        public ResultRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task Create(Result value)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Result>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Result value)
        {
            throw new NotImplementedException();
        }

        public Task Update(Result value)
        {
            throw new NotImplementedException();
        }
    }
}
