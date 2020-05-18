using bioResearchSystem.DAL.Implementations;
using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.Models.Repositories;

namespace bioResearchSystem.DAL.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private BioResearchSystemDbContext dbContext;
        private IRepositoryUser users;
        private IRepositoryResearch researches;
        private IRepositoryDevice devices;
        private IRepositoryExperiment experiments;
        private IRepositoryResult results;
        private IRepositoryObjective objectives;
        private IRepositoryTopic topics;
        private IRepositoryTag tags;
        private IRepositoryTagResearch tagresearches;
        private IWalletRepository wallets;

        public UnitOfWork(BioResearchSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

   

        public IRepositoryUser Users =>
            users ??= new UserRepository(dbContext);


        public IWalletRepository Wallets => 
            wallets ??= new WalletRepository(dbContext);

        public IRepositoryTopic Topic => 
            topics ??= new TopicRepository(dbContext);

        public IRepositoryResearch Researches =>
            researches ??= new ResearchRepository(dbContext);

        public IRepositoryResult Results =>
            results ??= new ResultRepository(dbContext);


        public IRepositoryObjective Objectives =>
            objectives ??= new ObjectiveRepository(dbContext);


        public IRepositoryTagResearch TagResearches =>
            tagresearches ??= new TagResearchRepository(dbContext);

        public IRepositoryExperiment Experiments =>
            experiments ??= new ExperimentRepository(dbContext);

        public IRepositoryDevice Devices =>
            devices ??= new DeviceRepository(dbContext);

        public IRepositoryTag Tags =>
            tags ??= new TagRepository(dbContext);
    }
}
