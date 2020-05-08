using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Results
{
    public interface IResultService
    {
        public Task AddResult(ResultDTO resultDto);
    }
}
