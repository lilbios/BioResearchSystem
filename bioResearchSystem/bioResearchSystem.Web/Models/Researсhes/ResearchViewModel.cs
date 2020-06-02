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
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime OpenedDate { get; set; }

        [Required]
        [UIHint("CreateNewResearch")]
        public string Description { get; set; }

        [Required]
        public Privacy Privacy { get; set; }

        public string Tags { get; set; }
        

    }
}
