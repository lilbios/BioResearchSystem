using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Web.Models.Accounts;
using bioResearchSystem.ВLL.Services.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        private readonly UserManager<AppUser> userManager;
      
        public AccountsController(IMapper mapper,IAccountService accountService, 
            UserManager<AppUser> userManager)
        {
            this.accountService = accountService;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Registration() {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }


        public async Task<IActionResult> Logout() {

            await accountService.Logout();
            //return RedirectToAction("Index", "Home");
            return null;
        }
        



        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel model)
        {
            var findUser = await accountService.FindUser(model.Email);

            if (findUser != null) {
                ModelState.AddModelError("ErrorMsg", "User already exsists");
            }
            
            if (ModelState.IsValid)
            {
                var user = mapper.Map<UserDTO>(model);
                user.UserName = $"user#{userManager.Users.Count() + 1}";
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
            var findUser = await accountService.FindUser(model.Email);

            if (findUser is null)
            {
                ModelState.AddModelError("ErrorMsg", "User doesn't exsist");
            }

            if (ModelState.IsValid)
            {
                var user = mapper.Map<UserDTO>(model);
                var result = await accountService.Login(user);
                if (result.Succeeded)
                {
              
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index), "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login and (or) password");
                }
            }
            return View(model);
        }
    }
}