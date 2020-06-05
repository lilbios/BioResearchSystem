using bioResearchSystem.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.DAL.Repositories
{
    public class ContractRepository:BaseRepository<Contract>, IRepositoryContract
    {
        public ContractRepository(BioResearchSystemDbContext dbContext) : base(dbContext)
        {

        }
    }
}
