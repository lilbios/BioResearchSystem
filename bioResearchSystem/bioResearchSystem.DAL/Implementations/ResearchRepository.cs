using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ResearchRepository:IRepositoryResearch
    {
        private readonly BioResearchSystemDbContex dbContext;
        public ResearchRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task Create(Research value)
        {
            throw new NotImplementedException();
        }

        public Task<Research> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Research>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Research value)
        {
            throw new NotImplementedException();
        }

        public Task Update(Research value)
        {
            throw new NotImplementedException();
        }
    }
}
