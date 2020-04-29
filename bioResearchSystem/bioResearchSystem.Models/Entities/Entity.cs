using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public abstract class Entity
    {
        [Required]
        public int Id { get; set; }
    }
}
