using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.DataAccess
{
    public interface IRepositoryTagResearch:IRepository<TagResearch>
    {
        public Task<ICollection<TagResearch>> GetAllwithIncludeAsync();
    }
}
