using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Tags
{
    public interface ITagService
    {
        public Task<Tag> AddTag(Tag tag);
        public Task<Tag> FindTag(string name);
        public Task AttachTag(Tag tag, Research research);
        public Task<ICollection<TagResearch>> GetRelatedTagsWithResearhes();
        
    }
}
