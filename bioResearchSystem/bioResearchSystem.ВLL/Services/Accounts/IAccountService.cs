using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Accounts
{
    public interface IAccountService
    {
        public Task<IdentityResult> Registration(UserDTO user);
        public Task<SignInResult> LogIn(UserDTO user);
        public Task Logout();
    }
}
