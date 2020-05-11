using AutoMapper;
using bioResearchSystem.Mvc.Models.Accounts;
using bioResearchSystem.ВLL.Services.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bioResearchSystem.Mvc.Controllers
{
    public class AccountController : Controller
    {

        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        public AccountController(IMapper mapper, IAccountService accountService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegisterViewModel registerViewModel)
        {

            var userDto = mapper.Map<UserDTO>(registerViewModel);
            var identityResult = await accountService.Registration(userDto);
            if (identityResult.Succeeded)
            {
                return RedirectToAction();
            }
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View(registerViewModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        
        


    }
}