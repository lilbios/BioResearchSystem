using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Entities
{
    public class Contract:Entity
    {
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Guid ResearchId { get; set; }
        public Research Research { get; set; }
    }
}
