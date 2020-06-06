﻿using System;
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
                .Select(item=> new TopTagListItem { 
                        TagName = item.Key.TagName,
                        Count = item.Count()
                        
                }).ToList()
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
                // researchDto.CreatorId = accountManager.GetUserId(User);
                researchDto.CreatorId = "0000-000-000-0000";

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
                return RedirectToAction(nameof(Index));
            }

            return View();
        }




        public IActionResult EditResearch(Guid id)
        {
            return View();
        }
        public IActionResult EditResearch(ResearchViewModel resarchView)
        {

            return View();
        }
        public IActionResult ResearchDetails(string id)
        {
            return View();
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

        public async Task<IActionResult> Search(string searchValue) {


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

                }).ToList()
            };

            return View(researchView);
        }

        [HttpGet]
        public async  Task<IActionResult> Tagged(int page,string tag)
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

                }).ToList()
            };

            return View(researchView);
        }






    }
}