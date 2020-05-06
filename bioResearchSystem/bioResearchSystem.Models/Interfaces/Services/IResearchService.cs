using System.Threading.Tasks;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface IResearchService<T> where T : class
    {
        public Task<T> СreateNewResearch(T research);
        public Task RemoveResearch(Guid id);

    }
}
