using System;

namespace bioResearchSystem.DTO.Entities
{
    public class Experiment:Entity
    {

        public DateTime StartedDate { get; set; }
        public DateTime FinishedDate { get; set; }
    }
}
