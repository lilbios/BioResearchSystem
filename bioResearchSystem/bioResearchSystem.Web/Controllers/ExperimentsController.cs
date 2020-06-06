using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using bioResearchSystem.Models.Entities;
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
        private readonly UserManager<AppUser> userManager;

        public ExperimentsController(IMapper mapper, IResultService resultService,UserManager<AppUser> userManager)
        {
            this.mapper = mapper;
            this.resultService = resultService;
            this.userManager = userManager;
        }

        public  async Task<IActionResult> CreateReport(string resultId, Format format)
        {
            var result = await resultService.GetResultAsync(Guid.Parse(resultId));
            return View();
        }

    }
}