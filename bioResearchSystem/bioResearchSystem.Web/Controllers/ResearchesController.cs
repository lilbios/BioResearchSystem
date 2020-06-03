using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Web.Models.Researсhes;
using bioResearchSystem.ВLL.Services.Accounts;
using bioResearchSystem.ВLL.Services.Researches;
using bioResearchSystem.ВLL.Services.Tags;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class ResearchesController : Controller
    {

        private readonly IMapper mapper;
        private readonly ITagService tagService;
        private readonly IResearchService researchService;
        private readonly UserManager<AppUser> accountManager;

        public ResearchesController(IMapper mapper, IResearchService researchService,
            ITagService tagService,UserManager<AppUser> accountManager)
        {
            
            this.mapper = mapper;
            this.accountManager = accountManager;
            this.tagService = tagService;
            this.researchService = researchService;

        }

        [HttpGet]
        public IActionResult Index(int numberPage = 1)
        {
            return View();
        }


        public IActionResult CreateNewResearch()
        {
            var researchViewModel = new ResearchViewModel {

                Privaces = Enum.GetValues(typeof(Privacy)).Cast<Privacy>().ToList()
            };
            return View(researchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewResearch(ResearchViewModel researchView)
        {
            if (ModelState.IsValid) {
                var researchDto = mapper.Map<ResearchDTO>(researchView);
                researchDto.CreatorId = accountManager.GetUserId(User);

                var research = await researchService.СreateNewResearch(researchDto);

                if (researchView.Tags != null) {

                    var collection = researchView.Tags.Split(',')
                        .ToList()
                        .Select(name => new Tag { TagName = name });

                    foreach (var item in collection)
                    {
                        var tag = await tagService.FindTag(item.TagName);

                        if (tag is null) {

                          tag =   await tagService.AddTag(item);
                        }
                        await tagService.AttachTag(tag, research);
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View();
        }




        public IActionResult EditResearch(int id)
        {
            return View();
        }
        public IActionResult EditResearch(ResearchViewModel resarchView)
        {

            return View();
        }
        public IActionResult ResearchDetails(Guid id)
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

        [HttpGet]
        public IActionResult ReleatedResearchTags(string tag)
        {
            return View();
        }






    }
}