using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Entities
{
    public class TagResearch:Entity
    {
        public Guid ReseachId { get; set; }
        public Research Research { get; set; }
        public Guid TagId { get; set; }

     }
}
