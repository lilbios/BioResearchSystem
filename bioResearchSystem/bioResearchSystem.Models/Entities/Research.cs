
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


        public int UserId { get; set; }
        public User User { get; set; }
 
        public int ExperimendId { get; set; }
        public Experiment Experiment { get; set; }

        public ICollection<Objective> Objectives { get; set; }
    }
}
