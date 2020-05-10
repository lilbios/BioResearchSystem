using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.API.Models;
using bioResearchSystem.ВLL.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper mapper;
        private readonly IAccountService accountService;
        public AccountController(IMapper mapper,IAccountService accountService)
        {
            this.mapper = mapper;
            this.accountService = accountService;
        }

        [HttpGet]
        public  IActionResult  SingUp() {
            return View();
        }


        [HttpGet]
        public  async IActionResult  Registration(RegisterViewModel registerViewModel) {

            var userDto = mapper.Map<UserDTO>(registerViewModel);
            var identityResult = await accountService.Registration(userDto);
            if (identityResult.Succeeded)
            {
                return RedirectToAction();
            }
            else { 
            
            
            }
            return View(registerViewModel);
            
            
        }
        
    }
}