using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bioResearchSystem.Models.Entities
{
    public class Branch : Entity
    {
        [Required]
        public string BranchName { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? LastUpdated { get; set; }
        public ICollection<Result> Results{ get; set; }

    }
}
