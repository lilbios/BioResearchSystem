using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Users
{
    public class LoginedUserViewModel
    {
        public string DefaultFullName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
     