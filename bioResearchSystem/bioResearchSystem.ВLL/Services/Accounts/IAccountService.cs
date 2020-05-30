using bioResearchSystem.Models.Entities;
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
        public Task<SignInResult> Login(UserDTO user);
        public Task Logout();
        public Task<AppUser> FindUser(string value);
        public Task<ICollection<AppUser>> FindUsers(string value);
        public Task<ICollection<AppUser>> GetUsers();
        public Task<ICollection<AppUser>> GetChunckedUsersCollection(int currentPage,int pageSize);
        public Task<int> CountAsync();
        public Task<ICollection<AppUser>> FindBySpecialKeyName(string nickname);
    }
}
