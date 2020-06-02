using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Web.Models.Researсhes;
using bioResearchSystem.ВLL.Services.Accounts;
using bioResearchSystem.ВLL.Services.Researches;
using bioResearchSystem.ВLL.Services.Tags;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class ResearchesController : Controller
    {

        private readonly IMapper mapper;
        private readonly ITagService repositoryTag;
        private readonly IResearchService researchService;

        public ResearchesController(IMapper mapper, IResearchService researchService
             , ITagService repositoryTag)
        {
            this.mapper = mapper;
            this.repositoryTag = repositoryTag;
            this.researchService = researchService;

        }

        [HttpGet]
        public IActionResult Index(int numberPage = 1)
        {
            return View();
        }


        public IActionResult CreateNewResearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewResearch(ResearchViewModel researchchView)
        {

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
        public IActionResult Details(int id)
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