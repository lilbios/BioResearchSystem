using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Repositories
{
    public class TagResearchRepository : BaseRepository<TagResearch>, IRepositoryTagResearch
    {
        public TagResearchRepository(BioResearchSystemDbContext dbContext) :base(dbContext)
        {

        }
        
    }
}
