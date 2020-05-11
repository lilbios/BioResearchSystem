using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.DataAccess
{
   public  interface IRepositoryTag:IRepository<Tag>
    {

        public Task<Tag> AddTag(Tag tag);
    }
}
