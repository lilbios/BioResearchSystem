using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Users
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }

        [Required(ErrorMessage ="user nickname cannot be empty")]
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Age { get; set; }

        public Gender Gender { get; set; }
        public Roles Role { get; set; }

        public byte[] Photo { get; set; }
        public bool IsAdmin { get; set; }
    }
}
