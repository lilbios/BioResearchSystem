using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly IMapper mapper;
        private readonly IRepositoryUser repositoryUser;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<AppUser> userManager, IRepositoryUser repositoryUser,
            SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager,
            IMapper mapper)
        {
            this.mapper = mapper;
            this.repositoryUser = repositoryUser;
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
                if (userDto.IsAdmin)
                {
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                }
                else
                {
                    await userManager.AddToRoleAsync(user, Roles.User.ToString());
                }

                await signInManager.SignInAsync(user, false);
            }
            return identityResult;
        }
        public async Task<SignInResult> Login(UserDTO model)
        {

            return await signInManager.PasswordSignInAsync(model.Email, model.Password,
                model.RememberMe, false);
        }
        public async Task<AppUser> FindUser(string email)
        {
            return await repositoryUser.Find(u => u.Email == email);
        }

        public async Task<ICollection<AppUser>> GetUsers()
        {
            return await userManager.Users.ToListAsync();
        }
    }
}
