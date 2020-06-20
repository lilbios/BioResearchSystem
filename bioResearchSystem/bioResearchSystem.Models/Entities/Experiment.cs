using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;

namespace bioResearchSystem.Models.Entities
{
    public class Experiment:Entity
    {
        public string NameExperiment { get; set; }
        public string Goal { get; set; }
        public StatusExperiment StatusExperiment { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public Guid ResearchId { get; set; }
        public Research Research { get; set; }
        public string JsonResult { get; set; }
        public string Data { get; set; }
    }
}
