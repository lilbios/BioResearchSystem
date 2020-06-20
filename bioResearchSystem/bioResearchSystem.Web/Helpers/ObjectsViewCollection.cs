using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Helpers
{
    public class ObjectsViewCollection<T>
    {
        public ICollection<T> Objects { get; set; }
        public PageModel PageViewModel { get; set; }
        public string SearchValue { get; set; }
    }
}
