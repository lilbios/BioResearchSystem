using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Services.Researches
{
    public class ResearchDTO
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public StatusResearch? StatusResearch { get; set; }

        
        public Privacy Privacy { get; set; }

        
        public DateTime OpenedDate { get; set; }
        public DateTime? ClosedDate { get; set; }


        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Experiment> Experiments { get; set; }
        public ICollection<TagResearch> TagResearches { get; set; }

        public ICollection<Objective> Objectives { get; set; }
    }
}
