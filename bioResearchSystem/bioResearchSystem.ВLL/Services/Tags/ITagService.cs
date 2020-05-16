using System;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Tags
{
    public interface ITagService
    {
        public Task AddTag(TagDTO tagDto);
        public Task RetrieveTag(TagDTO tag);
    }
}
