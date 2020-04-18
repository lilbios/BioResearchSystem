using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.DTO.Entities
{
    public class Result:Entity
    {
        [Required]
        public string ExperimentResult { get; set; }
        
    }
}
