using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public class Result : Entity
    {
        [Required]
        public string OrignalResult { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Experiment> Experiments { get; set; }  
    }
}
