using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using bioResearchSystem.Web.Helpers;
using bioResearchSystem.Web.Helpers.Researches;
using bioResearchSystem.Web.Models.Researсhes;
using bioResearchSystem.ВLL.Services.Researches;
using bioResearchSystem.ВLL.Services.Tags;
using bioResearchSystem.ВLL.Services.Topics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bioResearchSystem.Web.Controllers
{
    public class ResearchesController : Controller
    {

        private readonly IMapper mapper;
        private readonly ITagService tagService;
        private readonly IResearchService researchService;
        private readonly ITopicService topicService;
        private readonly UserManager<AppUser> accountManager;

        public ResearchesController(IMapper mapper, IResearchService researchService, ITopicService topicService,
            ITagService tagService, UserManager<AppUser> accountManager)
        {

            this.mapper = mapper;
            this.accountManager = accountManager;
            this.topicService = topicService;
            this.tagService = tagService;
            this.researchService = researchService;

        }

        [HttpGet]
        public async Task<IActionResult> ScientificResearches(int page = 1)
        {
            var relatedTagCollection = await tagService.GetRelatedTagsWithResearhes();
            var researches = await researchService.GetChunckedResearchCollection(page, (int)PageSizes.ResearchPageSize);
            int count = await researchService.ResearchCollectionLength();
            var pageModel = new PageModel(count, page, (int)PageSizes.UserPageSize);
            var researchView = new ResearchViewCollection
            {
                PageViewModel = pageModel,
                Objects = researches,
                TopTagListItems = relatedTagCollection.GroupBy(t => t.Tag)
                .Select(item => new TopTagListItem
                {
                    TagName = item.Key.TagName,
                    Count = item.Count()

                }).Take(10).ToList()
            };

            return View(researchView);
        }


        public async Task<IActionResult> CreateNewResearch()
        {
            var topics = await topicService.AllTopics();
            var researchViewModel = new ResearchViewModel
            {
                Topics = topics.Select(selectItem => new SelectListItem
                {
                    Value = selectItem.Id.ToString(),
                    Text = selectItem.TopicName
                }).ToList()
            };
            return View(researchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewResearch(ResearchViewModel researchView)
        {
            if (ModelState.IsValid)
            {
                var researchDto = mapper.Map<ResearchDTO>(researchView);
                var stringedUserId = HttpContext.Session.GetString("userId");
                if (!string.IsNullOrEmpty(stringedUserId))
                {
                    researchDto.AppUser = await accountManager.FindByIdAsync(stringedUserId);
                }
                else
                {
                    researchDto.AppUser = await accountManager.GetUserAsync(User);
                }

                var research = await researchService.СreateNewResearch(researchDto);

                if (researchView.Tags != null)
                {

                    var collection = researchView.Tags.Split(',')
                        .ToList()
                        .Select(name => new Tag { TagName = name });

                    foreach (var item in collection)
                    {
                        var tag = await tagService.FindTag(item.TagName);

                        if (tag is null)
                        {

                            tag = await tagService.AddTag(item);
                        }
                        await tagService.AttachTag(tag, research);
                    }
                }
                return RedirectToAction(nameof(ResearchDetails), new { id = research.Id.ToString() });
            }

            return View();
        }




        [HttpGet]
        public IActionResult ManageResearch(string id)
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult ManageResearch(ResearchViewModel resarchView)
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ResearchDetails(string id)
        {
            var selectedResearch = await researchService.GetResearchAsync(Guid.Parse(id));
            var stringedUserId = HttpContext.Session.GetString("userId");

            var user = !string.IsNullOrEmpty(stringedUserId) ?
                await accountManager.FindByIdAsync(stringedUserId) : await accountManager.GetUserAsync(User);


            if (selectedResearch != null && user != null)
            {
                var modelViewResearch = mapper.Map<ResearchModel>(selectedResearch);
                modelViewResearch.CurrentUser = user;
                modelViewResearch.IsParticipate = await researchService.IsHasContractWithResearch(user, selectedResearch);

                return View(modelViewResearch);
            }
            return NotFound();
        }



        public IActionResult Tags(string tagName)
        {
            return View();
        }

        [HttpGet]
        public IActionResult BoardObjective(int id)
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SearchResult( string searchValue)
        {
            var foundResearch = await researchService.Find(searchValue);
            var relatedTagCollection = await tagService.GetRelatedTagsWithResearhes();
           
            var researchView = new ResearchViewCollection
            { 
                SearchValue = searchValue,
                Objects = foundResearch,
                TopTagListItems = relatedTagCollection.GroupBy(t => t.Tag)
                .Select(item => new TopTagListItem
                {
                    TagName = item.Key.TagName,
                    Count = item.Count()

                }).Take(10).ToList()
            };
            return View(researchView);
        }

        [HttpGet]
        public async Task<IActionResult> Tagged(string tag)
        {
            var relatedTagCollection = await tagService.GetRelatedTagsWithResearhes();
            var researches = await researchService.GetResearchByTagName(tag);
            int count = await researchService.ResearchCollectionLength();
   
            var researchView = new ResearchViewCollection
            {
                TagName = tag,
                Objects = researches,
                TopTagListItems = relatedTagCollection.GroupBy(t => t.Tag)
                .Select(item => new TopTagListItem
                {
                    TagName = item.Key.TagName,
                    Count = item.Count()

                }).ToList()
            };

            return View(researchView);
        }
        public async Task<IActionResult> Join(string researchId)
        {
            var stringedUserId = HttpContext.Session.GetString("userId");
            var user = !string.IsNullOrEmpty(stringedUserId) ?
               await accountManager.FindByIdAsync(stringedUserId) : await accountManager.GetUserAsync(User);
            await researchService.JoinToResearch(user, Guid.Parse(researchId));

            return RedirectToAction(nameof(ResearchDetails), new { id = researchId });
        }

        //public Task<IActionResult> Leave(string id)
        //{

        //    return RedirectToAction(nameof(ResearchDetails), new { id = researchId });
        //}






    }
}