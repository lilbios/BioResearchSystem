using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Web.Models.Researсhes;
using bioResearchSystem.ВLL.Services.Accounts;
using bioResearchSystem.ВLL.Services.Researches;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class ResearchesController : Controller
    {
        
        private readonly IMapper mapper;
        private readonly IRepositoryTag repositoryTag;
        private readonly IResearchService researchService;
        private readonly IRepositoryTagResearch repositoryTagResearch;

        public ResearchesController(IMapper mapper, IResearchService researchService,
            IRepositoryTagResearch repositoryTagResearch,IRepositoryTag repositoryTag)
        {
            this.mapper = mapper;
            this.repositoryTag = repositoryTag;
            this.researchService = researchService;
            this.repositoryTagResearch = repositoryTagResearch;
        }

       [HttpGet]
        public IActionResult Index(int numberPage=1) {
            return View();
        }

        public IActionResult CreateNewResearch(ResearchViewModel resarchView) {

            return View();
        }
    }
}