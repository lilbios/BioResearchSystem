using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.Models.Interfaces.Services
{
    public interface IObjectService<T> where T : class
    {

        public void Attach(T objectve);
        public void Detach(Guid id);
        public void Edit(T objective);
    }
}
