using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Researсhes
{
    public class SearchModel
    {
        public string StringValue { get; set; }
        public ICollection<Research> SearchCollection { get; set; }
    }
}
