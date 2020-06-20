using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace bioResearchSystem.Web.Models.Experiments
{
    public class ExperimentModel
    {
        public Guid Id { get; set; }
        [Required]
        public string NameExperiment { get; set; }

        [Required]
        public string Goal { get; set; }
        public StatusExperiment StatusExperiment { get; set; }
        public DateTime StartedDate { get; set; }
        public Guid ResearchId { get; set; }
        public Research Research { get; set; }
        public IDictionary<string, int> Result { get; set; }
        public string Data { get; set; }
        public int Kmer { get; set; }

    }
}
