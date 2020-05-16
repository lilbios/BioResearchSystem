using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bioResearchSystem.Models.Entities
{
    public class AppUser : IdentityUser
    {

        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        public int Age { get; set; }

        public Wallet Wallet { get; set; }
        public Gender Gender { get; set; }

        public byte[] Photo { get; set; }
        public ICollection<Device> Devices { get; set; }
        public ICollection<Research> Researches { get; set; }

    }
}
