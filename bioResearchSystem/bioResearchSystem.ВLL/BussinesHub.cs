using bioResearchSystem.DAL;
using bioResearchSystem.ВLL.Components;
using bioResearchSystem.ВLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL
{
    public class BussinesHub
    {
        public IBussinesDevice Devises { get; private set; }
        public IBussinesUser Users { get; private set; }
        public IBussinesResearch Researches { get; private set; }
        public IBussinesResult Results { get; private set; }
        public IBussinesObjective Objectives { get; private set; }
        public IBussinesExperiment Experiments { get; private set; }
        public IBussinesTopic Topics { get; private set; }

        public BussinesHub(DataManager dataManager)
        {
            Devises = new BussinesDevice(dataManager);
            Users = new BussinesUser(dataManager);
            Researches = new BussinesResearch(dataManager);
            Experiments = new BussinesExperiment(dataManager);
            Topics = new BussinesTopic(dataManager);
            Objectives = new BussinesObjective(dataManager);
        }
    }
}
