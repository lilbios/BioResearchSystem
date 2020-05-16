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
        private IRepository<AppUser> users;
        private IRepository<Research> researches;
        private IRepository<Device> devices;
        private IRepository<Experiment> experiments;
        private IRepository<Result> results;
        private IRepository<Objective> objectives;
        private IRepository<Topic> topics;
        private IRepository<Tag> tags;
        private IRepository<TagResearch> tagresearches;
        private IRepository<Wallet> wallets;

        public UnitOfWork(BioResearchSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IRepository<AppUser> Users => 
            users ??= new BaseRepository<AppUser>(dbContext);


        public IRepository<Wallet> Wallets => 
            wallets ??= new BaseRepository<Wallet>(dbContext);

        public IRepository<Topic> Topic => 
            topics ??= new BaseRepository<Topic>(dbContext);

        public IRepository<Research> Researches =>
            researches ??= new BaseRepository<Research>(dbContext);

        public IRepository<Result> Results =>
            results ??= new BaseRepository<Result>(dbContext);


        public IRepository<Objective> Objectives =>
            objectives ??= new BaseRepository<Objective>(dbContext);


        public IRepository<TagResearch> TagResearches =>
            tagresearches ??= new BaseRepository<TagResearch>(dbContext);

        public IRepository<Experiment> Experiments =>
            experiments ??= new BaseRepository<Experiment>(dbContext);

        public IRepository<Device> Devices =>
            devices ??= new BaseRepository<Device>(dbContext);

        public IRepository<Tag> Tags =>
            tags ??= new BaseRepository<Tag>(dbContext);
    }
}
