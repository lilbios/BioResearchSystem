using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.DatabaseManager
{
    public interface IDatabaseManagerService
    {
        public Task CreateBackUpDb();
    }
}
