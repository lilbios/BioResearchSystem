using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace bioResearchSystem.Models.Entities
{
    public class Wallet:Entity
    { 
        public decimal Balance { get; set; }
        [ForeignKey("User")]

        public string UserId { get; set; }
        public AppUser User { get; set; } 
    }
}
