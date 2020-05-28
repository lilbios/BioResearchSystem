using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Services.Accounts
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public bool IsAdmin { get; set; }
        public bool RememberMe { get; set; }
    }
}
