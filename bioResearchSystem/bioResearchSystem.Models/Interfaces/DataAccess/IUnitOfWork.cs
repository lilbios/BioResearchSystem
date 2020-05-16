using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Interfaces.DataAccess
{
   public  interface IUnitOfWork
    {
        public IRepository<AppUser> Users { get; }
        public IRepository<Wallet> Wallets { get; }
        public IRepository<Topic> Topic { get; }
        public IRepository<Research> Researches { get; }
        public IRepository<Result> Results { get; }
        public IRepository<Objective> Objectives { get; }
        public IRepository<Tag> Tags { get; }
        public IRepository<TagResearch> TagResearches { get; }
        public IRepository<Experiment> Experiments { get; }
        public IRepository<Device> Devices { get; }
    }
}
