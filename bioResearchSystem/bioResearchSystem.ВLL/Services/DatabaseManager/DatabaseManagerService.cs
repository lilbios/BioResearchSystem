using bioResearchSystem.DAL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.DatabaseManager
{
    public class DatabaseManagerService : IDatabaseManagerService
    {

        private readonly IDbMaster dbMaster;
        public DatabaseManagerService(IDbMaster dbMaster)
        {
            this.dbMaster = dbMaster;
        }

        public async Task CreateBackUpDb() => 
            await dbMaster.ExcecuteBackUpProcedure();
       
    }
}
