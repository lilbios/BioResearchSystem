using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Experiments
{
    public class ExperimentModel
    {
        [Required]
        public string NameExperiment { get; set; }

        [Required]
        public string Goal { get; set; }
        public StatusExperiment StatusExperiment { get; set; }
        public DateTime StartedDate { get; set; }
        public Guid ResearchId { get; set; }
        public Research Research { get; set; }
        public string Result { get; set; }
        public string Data { get; set; }
       
    }
}
