using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class UserRepository:BaseRepository<User>,IRepositoryUser
    {
        public UserRepository(BioResearchSystemDbContext dbContext):base(dbContext)
        {

        }

        public Task CreateAsync(User value)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
