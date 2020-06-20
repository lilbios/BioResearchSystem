using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Web.Models.Accounts;
using bioResearchSystem.ВLL.Services.Accounts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountsController(IMapper mapper, IAccountService accountService,
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.accountService = accountService;
            this.userManager = userManager;
            this.mapper = mapper;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }


        public async Task<IActionResult> Logout()
        {

            await accountService.Logout();
            //return RedirectToAction("Index", "Home");
            return null;
        }




        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            var findUser = await accountService.FindUser(model.Email);

            if (findUser != null)
            {
                ModelState.AddModelError("ErrorMsg", "User already exsists");
            }

            if (ModelState.IsValid)
            {
                var user = mapper.Map<UserDTO>(model);
                user.UserName = $"user#{userManager.Users.Count() + 1}";
                user.Name = model.FullName.Split(" ").FirstOrDefault();
                user.LastName = model.FullName.Split(" ").LastOrDefault();
                user.IsAdmin = false;
                var result = await accountService.Registration(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ScientificResearches", "Researches");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var foundUser = await accountService.FindUser(model.Email);

            if (foundUser is null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
            }

            if (ModelState.IsValid)
            {
                var user = mapper.Map<UserDTO>(model);
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (foundUser != null)
                {
                    HttpContext.Session.SetString("userId", foundUser.Id);
                    if (await userManager.IsInRoleAsync(foundUser, Roles.Admin.ToString()))
                    {
                        return RedirectToAction("Users", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("ScientificResearches", "Researches");
                     
                    }
                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Invalid login attempt");

                }
            }
            return View(model);
        }
    }
}