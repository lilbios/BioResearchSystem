using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Topics
{
    interface ITopicService
    {
        public Task CreateTopic(TopicDTO topic);
        public Task UpdateTopic(TopicDTO topic);
        public Task RemoveTopic(Guid id);
        public Task<ICollection<Topic>> PopularTopics();
    }
}
