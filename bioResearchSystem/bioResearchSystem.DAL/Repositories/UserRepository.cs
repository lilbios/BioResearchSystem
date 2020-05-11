
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class UserRepository:BaseRepository<AppUser>,IRepositoryUser
    {
        public UserRepository(BioResearchSystemDbContext dbContext):base(dbContext)
        {

        }

        public Task CreateAsync(AppUser value)
        {
            return null;
        }

        public async Task<AppUser> GetAsync(string id)
        {
            var user = await dbSet.Include(d => d.Devices)
                .Include(r => r.Researches).FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
