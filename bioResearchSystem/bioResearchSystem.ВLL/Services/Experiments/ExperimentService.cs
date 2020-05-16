using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Models.Interfaces.DataAccess;
using bioResearchSystem.ВLL.Services.Experiments;
using System;
using System.Collections.Generic;
using System.Text;

namespace bioResearchSystem.ВLL.Services
{
    public class ExperimentService:IExperimentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ExperimentService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;

        }
    }
}
