using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Entities
{
    public class TagResearch:Entity
    {
        public Guid ResearchId { get; set; }
        public Research Research { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

     }
}
