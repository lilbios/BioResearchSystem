using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.DAL.Infrastructure
{
    public interface IDbMaster
    {
        public Task ExcecuteBackUpProcedure();
    }
}
