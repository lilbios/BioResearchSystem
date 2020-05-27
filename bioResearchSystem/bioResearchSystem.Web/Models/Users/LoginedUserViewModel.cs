using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Users
{
    public class LoginedUserViewModel
    {
        [Required]
        public string NickName { get; set; }
        [Required(ErrorMessage ="email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required")]
        [MinLength(10,ErrorMessage ="password length cannot be less than 10 charactes")]
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public bool AdminToggle { get; set; }
    }
}
     