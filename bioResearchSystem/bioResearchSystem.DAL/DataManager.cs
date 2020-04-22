using bioResearchSystem.DAL.Repositories;

namespace bioResearchSystem.DAL
{
    public class DataManager
    {
        public IRepositoryUser Users { get; private set; }
        public IRepositoryResearch Researches { get; private set; }
        public IRepositoryResult Results { get; private set; }
        public IRepositoryExperiment Experiments { get; private set; }
        public IRepositoryObjective Objectives { get; private set; }
        public IRepositoryDevice Devices { get; private set; }
        public IRepositoryTopic Topics { get; private set; }
        public DataManager(IRepositoryUser repositoryUser, IRepositoryResult repositoryResult,
            IRepositoryResearch repositoryResearch, IRepositoryExperiment repositoryExperiment,
            IRepositoryObjective repositoryObjective, IRepositoryDevice repositoryDevice,
            IRepositoryTopic repositoryTopic)
        {
            Users = repositoryUser;
            Researches = repositoryResearch;
            Results = repositoryResult;
            Experiments = repositoryExperiment;
            Objectives = repositoryObjective;
            Devices = repositoryDevice;
            Topics = repositoryTopic;
        }
    }

}

