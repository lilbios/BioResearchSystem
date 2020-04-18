using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.DTO.Entities
{
    public class Objective:Entity
    {
        [Required]
        public string Headline { get; set; }
        [Required]
        public string Description { get; set; }

        public bool Checked { get; set; }

        public ICollection<Research> Researches { get; set; }
    }
}
