using bioResearchSystem.Models.Entities;
using bioResearchSystem.ВLL.Services.Topics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class TopicService : ITopicService
    {
        public Task CreateTopic(TopicDTO topic)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Topic>> PopularTopics()
        {
            throw new NotImplementedException();
        }

        public Task RemoveTopic(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTopic(TopicDTO topic)
        {
            throw new NotImplementedException();
        }
    }
}
