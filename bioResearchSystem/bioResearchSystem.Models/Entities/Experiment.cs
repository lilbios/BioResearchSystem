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
        public ICollection<Research> Researches { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
