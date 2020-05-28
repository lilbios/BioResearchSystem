using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Repositories;
using bioResearchSystem.ВLL.Services.Topics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly IMapper mapper;
        private readonly IRepositoryTopic topicRepository;
        public TopicService(IRepositoryTopic topicRepository, IMapper _mapper)
        {
            mapper = _mapper;
            this.topicRepository = topicRepository;

        }

        public async  Task<ICollection<Topic>> AllTopics()
        {
            return await topicRepository.GetAllAsync();
        }

        public async Task CreateTopic(TopicDTO topicDto)
        {
            var topic = mapper.Map<Topic>(topicDto);
            await topicRepository.AddAsync(topic);

        }

        public async Task<TopicDTO> FindTopic(Guid guid)
        {
            var topic =  await topicRepository.GetAsync(guid);
            return mapper.Map<TopicDTO>(topic);
        }

        public async Task<ICollection<Topic>> PopularTopics()
        {
            var topics = await topicRepository.GetAllAsync();
            return topics.Take(10).ToList();
        }

        public async Task RemoveTopic(Guid id)
        {
            var topic = await topicRepository.GetAsync(id);
            await topicRepository.RemoveAsync(topic);
        }

        public async  Task UpdateTopic(TopicDTO topicDto)
        {
            var topic = mapper.Map<Topic>(topicDto);
            await topicRepository.UpdateAsync(topic);
        }
    }
}
