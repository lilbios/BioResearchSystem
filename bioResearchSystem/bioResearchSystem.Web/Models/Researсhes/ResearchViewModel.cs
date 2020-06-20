using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public DateTime OpenedDate { get; set; } = DateTime.Now;

        [Required]
        [UIHint("CreateNewResearch")]
        public string Description { get; set; }

        [Required]
        public Privacy Privacy { get; set; }

        public Topic Topic { get; set; }

        public List<Privacy> Privaces { get; set; }
        public List<SelectListItem> Topics { get; set; }
        public string Tags { get; set; }


    }
}
