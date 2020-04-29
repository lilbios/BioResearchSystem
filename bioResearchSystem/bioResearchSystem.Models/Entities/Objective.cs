using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public class Objective : Entity
    {
        [Required]
        public string Headline { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Checked { get; set; }
        public int ResearchId { get; set; }
        public Research Research { get; set; }

    }
}
