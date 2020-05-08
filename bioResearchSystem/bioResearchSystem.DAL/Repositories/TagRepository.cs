using bioResearchSystem.Context;
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

        public Task AddTag(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task AttachTag(Research research, Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task RemoveTag(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
