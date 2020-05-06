using System;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public abstract class Entity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
