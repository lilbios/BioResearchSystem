using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface ITopicService<T> where T : class
    {
        public Task CreateTopic(Topic topic);
        public Task UpdateTopic(Topic topic);
        public Task RemoveTopic(Guid id);
        public Task<ICollection<T>> PopularTopics();
        
    }
}
