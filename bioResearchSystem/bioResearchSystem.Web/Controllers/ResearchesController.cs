using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioResearchSystem.ВLL.Services.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class ResearchesController : Controller
    {

       [HttpGet]
        public IActionResult Index(int numberPage=1) {
            return View();
        }
    }
}