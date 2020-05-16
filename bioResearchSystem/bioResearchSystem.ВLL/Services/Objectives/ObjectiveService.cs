using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Objectives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bioResearchSystem.ВLL.Services
{
    public class ObjectiveService : IObjectiveService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ObjectiveService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;

        }

        public Task Attach(ObjectiveDTO objectveDto)
        {
            throw new NotImplementedException();
        }

        public void Detach(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Edit(ObjectiveDTO objectiveDto)
        {
            throw new NotImplementedException();
        }
    }
}
