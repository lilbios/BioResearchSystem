using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bioResearchSystem.Web.Models.Topics;
using Microsoft.AspNetCore.Mvc;

namespace bioResearchSystem.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        
        public IActionResult CreateNewTopic() {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNewTopic([FromForm]TopicViewModel topicView ) {

            return RedirectToAction(nameof(Index));
        }
        public IActionResult EditTopic() {
            return View();
        }

        public IActionResult AddUser() {
            return View();
        }

        public IActionResult EditUser() {
            return View();
        }

    }
}