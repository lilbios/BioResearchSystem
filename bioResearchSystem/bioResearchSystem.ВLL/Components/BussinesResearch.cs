using bioResearchSystem.DAL;
using bioResearchSystem.ВLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Components
{
    public class BussinesResearch: BussinesMaster<Research>, IBussinesResearch
    {
        public BussinesResearch(DataManager dataManager):base(dataManager)
        {

        }
    }
}
