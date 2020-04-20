using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class ObjectiveRepository:IRepositoryObjective
    {
        private readonly BioResearchSystemDbContex dbContext;
        public ObjectiveRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public Task Create(Objective value)
        {
            throw new NotImplementedException();
        }

        public Task<Objective> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Objective>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Remove(Objective value)
        {
            throw new NotImplementedException();
        }

        public Task Update(Objective value)
        {
            throw new NotImplementedException();
        }
    }
}
