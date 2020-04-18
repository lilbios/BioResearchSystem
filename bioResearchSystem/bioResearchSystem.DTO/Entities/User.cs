using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.DTO.Entities
{
    public class User : Entity
    {
        [Required]
        [MinLength(3,ErrorMessage ="Your name must be more than 3 charactes")]
        public string Name { get; set; }
        public int Age { get; set; }

        public bool IsSuperVisor { get; set; }

        [DefaultValue(Gender.None)]
        public Gender Gender { get; set; }

        [DefaultValue(Roles.User)]
        public Roles Roles { get; set; }


        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Required field")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Required field")]
        [MinLength(11, ErrorMessage = "Password to short")]
        public string Password { get; set; }

        public byte[] Photo { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<Research> Researches { get; set; }

    }
}
