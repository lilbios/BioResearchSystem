using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;

namespace bioResearchSystem.Models.Entities
{
    public class Experiment:Entity
    {

        public StatusExperiment StatusExperiment { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public Guid ResearchId { get; set; }
        public Guid ResultId { get; set; }
        public Result Result { get; set; }
        public Research Research { get; set; }
    }
}
