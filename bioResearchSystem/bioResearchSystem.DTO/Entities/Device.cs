using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.DTO.Entities
{
    public class Device:Entity
    {
        [MinLength(4,ErrorMessage = "Alias  should be more than 3 charactes")]
        [MaxLength(16,ErrorMessage ="Alias must be less then 16 charactes")]
        [DefaultValue("Device")]
        public string Alias { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
