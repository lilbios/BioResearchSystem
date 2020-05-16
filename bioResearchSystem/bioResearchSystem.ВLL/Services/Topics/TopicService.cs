using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Topics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class TopicService : ITopicService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public TopicService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

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
