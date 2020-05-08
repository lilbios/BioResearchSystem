using bioResearchSystem.Mode;
using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Repositories
{
    public class TagRepository:BaseRepository<Tag>,IRepositoryTag
    {
        public TagRepository(BioResearchSystemDbContext dbContext):base(dbContext)
        {

        }

        public async Task<Tag> AddTag(Tag tag)
        {
            await dbSet.AddAsync(tag);
            await dbContext.SaveChangesAsync();
            return tag;
        }

        public Task AttachTag(Research research, Tag tag)
        {
            throw new NotImplementedException();
        }

       
    }
}
