using bioResearchSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface IObjectiveService
    {

        public void Attach(Objective objectve);
        public void Detach(Guid id);
        public void Edit( objective);
    }
}
