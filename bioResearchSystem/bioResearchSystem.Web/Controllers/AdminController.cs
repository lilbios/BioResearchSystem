using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper mapper;
        private readonly ITopicService topicService;
        private readonly IAccountService accountService;
        private readonly UserManager<AppUser> accountManager;

        public AdminController(IAccountService accountService, ITopicService topicService,
             IMapper mapper, UserManager<AppUser> accountManager)
        {
            this.mapper = mapper;
            this.topicService = topicService;
            this.accountService = accountService;
            this.accountManager = accountManager;

        }

        [HttpGet]
        public async Task<IActionResult> SearchUser(string value)
        {


            if (value.StartsWith('@') && value.Length > 2)
            {
                var foundNickNames = await accountService.FindBySpecialKeyName(value.Substring(1));
                var viewModel = new UsersViewCollection
                {

                    Objects = foundNickNames,
                    IdCurrentUser = accountManager.GetUserId(User)
                };
                return View(viewModel);
            }
            else
            {
                var foundEmails = await accountService.FindUsers(value);
                var viewModel = new UsersViewCollection
                {

                    Objects = foundEmails,
                    IdCurrentUser = accountManager.GetUserId(User)
                };

                return View(viewModel);
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
                Objects = users,
                IdCurrentUser = accountManager.GetUserId(User)
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
                return RedirectToAction(nameof(Panel));
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
        public async Task<IActionResult> EditTopic(string id)
        {

            var selectedTopic = await topicService.FindTopic(Guid.Parse(id));
            if (selectedTopic != null)
            {
                var topicViewModel = mapper.Map<TopicViewModel>(selectedTopic);
                return RedirectToAction(nameof(Panel));
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

        [HttpPost]
        public async Task<IActionResult> RemoveUser(string id)
        {

            var user = await accountService.GetUserByIdAsync(id);
            if (user != null)
            {
                await accountService.DeleteUser(user);
                return Ok(HttpStatusCode.OK);
            }
            return BadRequest(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public IActionResult PostUserSearch(string val) {

            return RedirectToAction(nameof(SearchUser), new {value = val });
        }


        [HttpGet]
        public async Task<IActionResult> ModifyUser(string id)
        {

            var user = await accountService.GetUserByIdAsync(id);
            if (user != null)
            {
                var profile = mapper.Map<ProfileViewModel>(user);
                profile.IsAdmin = user.Role == Roles.Admin;

                return View(profile);
            }
            return NotFound();


        }

        [HttpPost]
        public async Task<IActionResult> ModifyUser(ProfileViewModel user)
        {

            if (ModelState.IsValid)
            {

                if (Request.Form.Files.Count == 1)
                {
                    user.Photo = ImageConvertor.ConvertImageToBytes(Request.Form.Files[0]);
                }

                user.Role = user.IsAdmin ? Roles.Admin : Roles.User;
                var userDto = mapper.Map<UserDTO>(user);

                var identityResult = await accountService.UpdateUserAsync(user.Id, userDto);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction(nameof(Users));
                }
                else
                {
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return View(user);

        }

    }

}
