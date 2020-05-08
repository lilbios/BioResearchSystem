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
    public class TopicRepository:BaseRepository<Topic>,IRepositoryTopic
    {
        public TopicRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        {

        }
    }
}
