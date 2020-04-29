using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public class User : Entity
    {
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsSuperVisor { get; set; }

        public Gender Gender { get; set; }

        public Roles Roles { get; set; }


        [Required]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required field")]
        [MinLength(11, ErrorMessage = "Password to short")]
        public string Password { get; set; }

        public byte[] Photo { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<Research> Researches { get; set; }

    }
}
