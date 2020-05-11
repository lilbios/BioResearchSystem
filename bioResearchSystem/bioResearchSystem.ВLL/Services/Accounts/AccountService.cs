using AutoMapper;
using bioResearchSystem.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Accounts
{
    public class AccountService: IAccountService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IMapper mapper;
        public AccountService(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        public async Task<SignInResult> LogIn(UserDTO userDto)
        {
            return null;

        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Registration(UserDTO userDto)
        {
            var user = mapper.Map<AppUser>(userDto);
            var identityResult = await userManager.CreateAsync(user, userDto.Password);
            if (identityResult.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
            }
            return identityResult;
        }

        
    }
}
