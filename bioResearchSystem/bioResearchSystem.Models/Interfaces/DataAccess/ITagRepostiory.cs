using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.DataAccess
{
   public  interface ITagRepostiory
    {

        public Task AddTag(Tag tag);
        public Task RemoveTag(Tag tag);
        public Task AttachTag(Research research, Tag tag);
    }
}
