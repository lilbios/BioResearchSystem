using bioResearchSystem.DAL;
using bioResearchSystem.ВLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Components
{
    public class BussinesTopic : BussinesMaster<Topic>, IBussinesTopic
    {
        public BussinesTopic(DataManager dataManager) : base(dataManager)
        {

        }
    }
}
