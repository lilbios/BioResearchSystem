using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioResearchSystem.ВLL.Services.Researches;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.API.Controllers
{
    [Route("researches")]
    public class ResearchesController : Controller
    {
        private readonly IResearchService researchService;
        public ResearchesController(IResearchService researchService)
        {
            this.researchService = researchService;
        }
        [HttpGet]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Index() { 
                var researches = await researchService.f
        }

    }
}