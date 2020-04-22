﻿using bioResearchSystem.Context;
using bioResearchSystem.DAL.Repositories;
using bioResearchSystem.DTO.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Implementations
{
    public class TopicRepository : IRepositoryTopic
    {
        private readonly BioResearchSystemDbContex dbContext;
        public TopicRepository(BioResearchSystemDbContex _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task Create(Topic value)
        {

            dbContext.Topics.Add(value);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Topic> Get(int id)
        {
            var topic = await dbContext.Topics
                .Include(r => r.Researches)
                .FirstOrDefaultAsync(t => t.Id == id);
            return topic;
        }

        public async Task<ICollection<Topic>> GetAll()
        {
            var topics = await dbContext.Topics
                 .Include(r => r.Researches)
                 .ToListAsync();
            return topics;
        }

        public async Task Remove(Topic value)
        {
            var topic = await Get(value.Id);
            if (topic != null)
            {

                dbContext.Topics.Remove(topic);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task Update(Topic value)
        {
            dbContext.Entry(value).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
