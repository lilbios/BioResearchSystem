using bioResearchSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Infrastructure
{
    public class DbMaster : IDbMaster
    {
        private readonly BioResearchSystemDbContext dbContext;
        public DbMaster(BioResearchSystemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task ExcecuteBackUpProcedure()
        {
            var dateParameter = new SqlParameter("@Date", DateTime.Now.ToString("MM-dd-yyyy"));
            await dbContext.Database.ExecuteSqlRawAsync("sp_create_backup @Date",dateParameter);
        }
        
    }
}
