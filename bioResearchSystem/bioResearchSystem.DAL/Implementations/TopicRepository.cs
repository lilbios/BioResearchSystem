using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class TopicRepository:IRepositoryTopic
    {
        private readonly BioResearchSystemDbContex dbContext;
        public TopicRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task Create(Topic value)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Topic>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Topic value)
        {
            throw new NotImplementedException();
        }

        public Task Update(Topic value)
        {
            throw new NotImplementedException();
        }
    }
}
