using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using bioResearchSystem.Web.Helpers;
using bioResearchSystem.Web.Helpers.Users;
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


        public async Task<IActionResult> Search(string value) {


            if (value.StartsWith('@') && value.Length > 2)
            {
                var foundNickNames = await accountService.FindBySpecialKeyName(value.Substring(1));
                return View(foundNickNames);
            }
            else {
                var foundEmails = await accountService.FindUsers(value);
                return View(foundEmails);
            }


        }

        [HttpGet]
        public IActionResult CreateNewTopic()
        {
            return View();
        }

        public async Task<IActionResult> Users(int page = 1)
        {
            var users = await accountService.GetChunckedUsersCollection(page, (int)PageSizes.UserPageSize);
           int count = await accountService.CountAsync();
            var pageModel = new PageModel(count, page, (int)PageSizes.UserPageSize);
            var viewModel = new UsersViewCollection
            {
                PageViewModel = pageModel,
                Objects = users
            };

            return View(viewModel);
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
                mappedUser.Role = loginView.IsAdmin ? Roles.Admin : Roles.User;
                var result = await accountService.Registration(mappedUser);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
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

        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditTopic(string id)
        {

            var selectedTopic = await topicService.FindTopic(Guid.Parse(id));
            if (selectedTopic != null)
            {
                var topicViewModel = mapper.Map<TopicViewModel>(selectedTopic);
                return View(topicViewModel);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditTopic(TopicViewModel topicView)
        {

            var topic = await topicService.FindTopic(topicView.Id);
            if (topic is null)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong...Topic is not defined");
            }
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
                if (topicView.TopicName is null && topic != null)
                {
                    topic.TopicName = topic.TopicName;
                }

                var mappedTopic = mapper.Map<TopicDTO>(topicView);
                await topicService.UpdateTopic(mappedTopic);
            }
            return View(topicView);
        }





        public async Task<IActionResult> Panel()
        {
            var topics = await topicService.AllTopics();
            return View(topics);

        }

    }
}