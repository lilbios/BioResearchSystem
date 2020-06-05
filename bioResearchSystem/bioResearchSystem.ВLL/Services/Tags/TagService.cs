using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Tags;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class TagService : ITagService
    {

        private readonly IMapper mapper;
        private readonly IRepositoryTag repositoryTag;
        private readonly IRepositoryTagResearch repositoryTagResearch;

        public TagService(IMapper _mapper, IRepositoryTag repositoryTag,
            IRepositoryTagResearch repositoryTagResearch)
        {
            this.repositoryTagResearch = repositoryTagResearch;
            this.repositoryTag = repositoryTag;
            mapper = _mapper;
        }

        public async Task<Tag> AddTag(Tag tag)
        {
            return await repositoryTag.AddTag(tag);
        }

        public async Task AttachTag(Tag tag, Research research)
        {
            var attached = new TagResearch
            {
                TagId = tag.Id,
                ReseachId = research.Id,
            };
            await repositoryTagResearch.AddAsync(attached);
        }

        public async Task<Tag> FindTag(string name)
        {
            return await repositoryTag.Find(tag => tag.TagName == name);
        }

        public async  Task<ICollection<TagResearch>> GetRelatedTagsWithResearhes()
        {
            return await repositoryTagResearch.GetAllAsync();
        }

        
    }
}
