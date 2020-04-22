using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task Create(User value)
        {
            dbContext.Users.Add(value);
            await dbContext.SaveChangesAsync();
        }

        public async Task<User> Get(int id)
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

        public async Task Update(User value)
        {
            dbContext.Entry(value).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
