using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class UserRepository:IRepositoryUser
    {
        private readonly BioResearchSystemDbContex dbContext;
        public UserRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task Create(User value)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(User value)
        {
            throw new NotImplementedException();
        }

        public Task Update(User value)
        {
            throw new NotImplementedException();
        }
    }
}
