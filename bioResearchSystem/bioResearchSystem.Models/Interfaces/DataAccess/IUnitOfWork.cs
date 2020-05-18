using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Interfaces.DataAccess
{
   public  interface IUnitOfWork
    {
        public IRepositoryUser Users { get; }
        public IWalletRepository Wallets { get; }
        public IRepositoryTopic Topic { get; }
        public IRepositoryResearch Researches { get; }
        public IRepositoryResult Results { get; }
        public IRepositoryObjective Objectives { get; }
        public IRepositoryTag Tags { get; }
        public IRepositoryTagResearch TagResearches { get; }
        public IRepositoryExperiment Experiments { get; }
        public IRepositoryDevice Devices { get; }
    }
}
