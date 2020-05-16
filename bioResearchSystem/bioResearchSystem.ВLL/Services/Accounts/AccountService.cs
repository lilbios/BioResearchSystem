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
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        
        public AccountService(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,  RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            
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
        public async Task<SignInResult> Login(UserDTO model) { 
        
            return await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        }

        
    }
}
