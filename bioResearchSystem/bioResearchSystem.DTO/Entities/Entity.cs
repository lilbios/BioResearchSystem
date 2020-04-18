using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.DTO.Entities
{
    public abstract class Entity
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
