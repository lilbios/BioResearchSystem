using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            user.Role = userDto.IsAdmin ? Roles.Admin : Roles.User;
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

        public async Task<ICollection<AppUser>> GetChunckedUsersCollection(int currentPage, int pageSize)
        {
            return await userManager.Users.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return users.Count;
        }

        public async Task<ICollection<AppUser>> FindUsers(string value)
        {
            var searchResult = await Task.Run(() => userManager.Users.Where(u => u.Email.StartsWith(value)));
            return await searchResult.ToListAsync();
        }

        public async Task<ICollection<AppUser>> FindBySpecialKeyName(string nickname)
        {
            var searchResult = await Task.Run(() => userManager.Users.Where(u => u.UserName.StartsWith(nickname)));
            return await searchResult.ToListAsync();
        }

        public async Task DeleteUser(AppUser appUser)
        {

          
            var result  = await userManager.DeleteAsync(appUser);
            if (result.Succeeded) {
                string a = "aaaa";
            }
        }

        public async Task<AppUser> GetUser(Expression<Func<AppUser, bool>> expession)
        {
            return await userManager.Users.FirstOrDefaultAsync(expession);
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await userManager.FindByIdAsync(id);

        }

        public async Task<IdentityResult> UpdateUserAsync(string id, UserDTO _user)
        {

            var user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                _user.Photo ??= user.Photo;
                if (_user.UserName != user.UserName || _user.Email != user.Email)
                {
                    user.UserName = _user.UserName;
                    user.Email = _user.Email;
                }
                var role = await userManager.GetRolesAsync(user);
                var olderUser = user;

                user.Name = _user.Name;
                user.LastName = _user.LastName;
                user.Bio = _user.Bio;
                user.Role = _user.Role;
                user.Photo = _user.Photo;
              


                var identityResult = await userManager.UpdateAsync(user);
                if (identityResult.Succeeded)
                {
                    await userManager.RemoveFromRoleAsync(olderUser, role.FirstOrDefault());
                    await userManager.AddToRoleAsync(user, user.Role.ToString());

                }
                return identityResult;

            }
            return IdentityResult.Failed();
        }
    }
}
