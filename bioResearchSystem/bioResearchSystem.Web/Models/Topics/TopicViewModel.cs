using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Models.Topics
{
    public class TopicViewModel
    {
        public string Title { get; set; }
        public IFormFile Image { get; set; }
    }
}
