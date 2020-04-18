using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.DTO.Entities
{
    public class Research
    {
        [Required(ErrorMessage = "Required field")]
        public string  Title {get;set;}

        [Required(ErrorMessage ="Required field")]
        [MinLength(50,ErrorMessage = "Describe the researching in more detail so that other people can understand what it is about")]
        public string Description { get; set; }

        [DefaultValue(StatusResearch.InProgress)]
        public StatusResearch StatusResearch { get; set; }

        public DateTime OpenedDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public ICollection<Experiment> Experiments { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ExperimendId { get; set; }
        public Experiment Experiment { get; set; }
    }
}
