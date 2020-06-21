using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AutoMapper;
using BioAlgo.BioAlgorthims.Algorithms.KmersComputing;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Enums;
using bioResearchSystem.Web.Models.Experiments;
using bioResearchSystem.ВLL.Services.Experiments;
using bioResearchSystem.ВLL.Services.Researches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using SciReport;

namespace bioResearchSystem.Web.Controllers
{
    public class ExperimentsController : Controller
    {
        private readonly IMapper mapper;
        private readonly IResearchService researchService;
        private readonly IExperimentService experimentService;
        private readonly UserManager<AppUser> userManager;

        public ExperimentsController(IMapper mapper, IExperimentService experimentService, IResearchService researchService,
             UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.experimentService = experimentService;
            this.researchService = researchService;
        }

        public async Task<IActionResult> CreateReportXml(string experimentId)
        {
            var experiment = await experimentService.GetExperimentAsync(Guid.Parse(experimentId));
            if (experiment != null)
            {
                var resultDictionary = JsonConvert.DeserializeObject<IDictionary<string, int>>(experiment.JsonResult);
                var xElement = new XElement("experiment-resut-root", resultDictionary.Select(kv => new XElement(kv.Key, kv.Value)));
                var xmlDocument = new XDocument();
                xmlDocument.Add(xElement);
                return File(new MemoryStream(Encoding.Unicode.GetBytes(xmlDocument.ToString().ToArray())), "application/xml", "experiment-result.xml"); ;
            }

            return NotFound();
        }

        public async Task<IActionResult> MyLaboratory()
        {
            var stringedUserId = HttpContext.Session.GetString("userId");
            var user = await userManager.FindByIdAsync(stringedUserId);
            var userExperiments = await experimentService.GetUsersExperiments(user.Id);
            return View(userExperiments);
        }

        [HttpGet]
        public async Task<IActionResult> CreateExperiment(string researchId)
        {
            var research = await researchService.GetResearchAsync(Guid.Parse(researchId));

            var experimentModel = new ExperimentModel()
            {
                Research = research,
                ResearchId = research.Id
            };
            return View(experimentModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperiment(ExperimentModel experimentModel)
        {


            if (ModelState.IsValid)
            {
                var mappedExperiment = mapper.Map<Experimet>(experimentModel);
                mappedExperiment.StatusExperiment = StatusExperiment.NotStarted;
                var experiment = await experimentService.CreateNewExperiment(mappedExperiment);
                return RedirectToAction(nameof(ExperimentProcess), new { id = experiment.Id });
            }
            return View();



        }


        [HttpGet]
        public async Task<IActionResult> ExperimentProcess(Guid id)
        {
            if (id != null)
            {
                var experiment = await experimentService.GetExperimentAsync(id);
                var mappedExperiment = mapper.Map<ExperimentModel>(experiment);
                if (experiment.JsonResult != null) mappedExperiment.Result = JsonConvert.DeserializeObject<IDictionary<string, int>>(experiment.JsonResult);
                return View(mappedExperiment);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ExperimentProcess(ExperimentProcess exp)
        {
            if (ModelState.IsValid)
            {
                var experiment = await experimentService.CreateNewExperiment(mapper.Map<Experimet>(exp));
                return RedirectToAction(nameof(ExperimentProcess), new { id = experiment.Id });
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> GetData(string id)
        {
            var serialtPort = new SerialPort();
            serialtPort.BaudRate = 9600;
            serialtPort.PortName = "COM5";
            var strb = new StringBuilder();
            var experiment = await experimentService.GetExperimentAsync(Guid.Parse(id));

            var result = await Task.Run(() =>
            {
                while (strb.Length != 1000)
                {
                    var generatedData = serialtPort.ReadLine();
                    strb.Append(generatedData);
                }
                return strb.ToString();
            });
            experiment.Data = result;
            experiment.StatusExperiment = StatusExperiment.InProgress;
            await experimentService.UpdeteExperiment(experiment);
            return RedirectToAction(nameof(ExperimentProcess), new { id = experiment.Id });
        }

        [HttpPost]
        public async Task<IActionResult> StratProcessing(ExperimentModel exp)
        {
            if (ModelState.IsValid)
            {
                var kmc = new KMC();
                var experiment = await experimentService.GetExperimentAsync(exp.Id);
                var processedData = kmc.BuildAcidDictionary(exp.Kmer, exp.Data);
                experiment.JsonResult = JsonConvert.SerializeObject(processedData);
                experiment.StatusExperiment = StatusExperiment.Done;
                await experimentService.UpdeteExperiment(experiment);
                return RedirectToAction(nameof(ExperimentProcess), new { id = experiment.Id });
            }
            return View();
        }
    }
}