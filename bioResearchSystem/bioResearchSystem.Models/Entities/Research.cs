
using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public class Research:Entity
    {
        [Required]
        public string  Title {get;set;}

        [Required]
        public string Description { get; set; }

        public StatusResearch? StatusResearch { get; set; }

        [Required]
        public Privacy Privacy { get; set; }

        [Required]
        public DateTime OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
 
        public ICollection<Experiment> Experiments { get; set; }
        public ICollection<TagResearch> TagResearches { get; set; }
        public ICollection<Contract> Contracts { get; set; }

        public ICollection<Objective> Objectives { get; set; }
    }
}
