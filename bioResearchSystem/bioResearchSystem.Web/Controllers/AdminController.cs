using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using bioResearchSystem.Web.Models.Topics;
using bioResearchSystem.Web.Models.Users;
using bioResearchSystem.ВLL.Services.Accounts;
using bioResearchSystem.ВLL.Services.Topics;
using bioResearchSystem.ВLL.Third_part.pic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        private IMapper mapper;
        private ITopicService topicService;
        private IAccountService accountService;

        public AdminController(IAccountService accountService, ITopicService topicService, IMapper mapper)
        {
            this.mapper = mapper;
            this.topicService = topicService;
            this.accountService = accountService;


        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNewTopic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewTopic(TopicViewModel topicView)
        {

            if (Request.Form.Files.Count != 1)
            {
                ModelState.AddModelError("Image", "image cannot be empty");
            }
            else
            {
                topicView.TopicPicture = ImageConvertor.ConvertImageToBytes(Request.Form.Files[0]);
            }

            if (ModelState.IsValid)
            {
                var mappedTopic = mapper.Map<TopicDTO>(topicView);
                await topicService.CreateTopic(mappedTopic);
            }
            return View(topicView);

        }
        public IActionResult EditTopic()
        {
            return View();
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(LoginedUserViewModel loginView)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count == 1)
                {
                    loginView.Photo = ImageConvertor.ConvertImageToBytes(Request.Form.Files[0]);
                }

                var mappedUser = mapper.Map<UserDTO>(loginView);
               var result =  await accountService.Registration(mappedUser);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Panel));
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return View(loginView);
        }

        public IActionResult EditUser()
        {
            return View();
        }
        public IActionResult Panel()
        {
            return View();
        }

    }
}