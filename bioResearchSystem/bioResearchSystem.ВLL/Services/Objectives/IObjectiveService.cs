using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services.Objectives
{
    public interface IObjectiveService
    {
        public Task Attach(ObjectiveDTO objectveDto);
        public void Detach(Guid id);
        public Task Edit(ObjectiveDTO objectiveDto);
    }
}
