
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Mode;
using bioResearchSystem.Models;
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
            return null;
        }

        public async Task<User> GetAsync(string id)
        {
            var user = await dbSet.Include(d => d.Devices)
                .Include(r => r.Researches).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
