using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Researсhes
{
    public class ResearchViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Privacy Privacy { get; set; }

        public List<Tag> Tags { get; set; }

    }
}
