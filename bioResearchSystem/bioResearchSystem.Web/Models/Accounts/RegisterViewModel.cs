using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Accounts
{
    public class RegisterViewModel : CommonViewModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "password")]
        [MinLength(10,ErrorMessage ="Your password to short!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passswords doesn't equals")]
        public string PasswordConfirm { get; set; }
        

    }
}
