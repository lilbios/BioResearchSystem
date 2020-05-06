using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class UserRepository : IRepositoryUser
    {
        private readonly BioResearchSystemDbContext dbContext;
        public UserRepository(BioResearchSystemDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(User value)
        {
            await dbContext.Users.AddAsync(value);
            await dbContext.SaveChangesAsync();
        }


        public async Task<User> Get(string id)
        {
            var user = await dbContext.Users
                .Include(d => d.Devices)
                .Include(e => e.Researches)
                .FirstOrDefaultAsync(u => u.Id == id);
            return user;

        }

        public async Task<ICollection<User>> GetAll()
        {
            var users = await dbContext.Users
                .Include(d => d.Devices)
                .Include(e => e.Researches)
                .ToListAsync();
            return users;
        }

        public async Task Remove(User value)
        {
            var user = await Get(value.Id);
            if (user != null)
            {
                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task Update(User user)
        {
            dbContext.Entry(user).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
