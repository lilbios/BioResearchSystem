using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Web.Models.Experiments;
using bioResearchSystem.ВLL.Services.Experiments;
using bioResearchSystem.ВLL.Services.Researches;
using bioResearchSystem.ВLL.Services.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SciReport;

namespace bioResearchSystem.Web.Controllers
{
    public class ExperimentsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IResultService resultService;
        private readonly IResearchService researchService;
        private readonly IExperimentService experimentService;
        private readonly UserManager<AppUser> userManager;

        public ExperimentsController(IMapper mapper, IExperimentService experimentService, IResearchService researchService,
            IResultService resultService, UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.resultService = resultService;
            this.userManager = userManager;
            this.experimentService = experimentService;
            this.researchService = researchService;
        }

        public async Task<IActionResult> CreateReport(string resultId, Format format)
        {
            var result = await resultService.GetResultAsync(Guid.Parse(resultId));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateExperiment(string researchId) {
            var research = await researchService.GetResearchAsync(Guid.Parse(researchId));

            var experimentModel = new ExperimentModel()
            {
                Research = research,
                ResearchId = research.Id
            };
            return View(experimentModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperiment(ExperimentModel experimentModel) {

           
            if (ModelState.IsValid) {
                var mappedExperiment = mapper.Map<Experiment>(experimentModel);
                var experiment = await experimentService.CreateNewExperiment(mappedExperiment);
                return RedirectToAction(nameof(ExperimentProcess), new { id = experiment.Id });
            }
            return View();
            

        
        }


        [HttpGet]
        public async Task<IActionResult> ExperimentProcess(Guid id)
        {
            var experiment = await experimentService.GetExperimentAsync(id);
            return View(experiment);
        }


        //[HttpGet]
        //public async Task<IActionResult> GetData(Guid id) {

        //    return RedirectToAction(nameof(ExperimentProcess), new { id = null});
        //}

        //[HttpPost]
        //public async Task<IActionResult> StratProcessing() {


        //    return View();
        //}






    }
}