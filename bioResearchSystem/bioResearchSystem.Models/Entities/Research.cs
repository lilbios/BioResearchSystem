
using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public class Research:Entity
    {
        [Required]
        public string  Title {get;set;}

        [Required]
        public string Description { get; set; }

        public StatusResearch StatusResearch { get; set; }

        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }
 
        public Guid ExperimendId { get; set; }
        public Experiment Experiment { get; set; }
        public ICollection<TagResearch> TagResearches { get; set; }

        public ICollection<Objective> Objectives { get; set; }
    }
}
