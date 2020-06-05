using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Helpers.Researches
{
    public class ResearchViewCollection : ObjectsViewCollection<Research>
    {
        public List<TopTagListItem> TopTagListItems { get; set; }
    }
}
