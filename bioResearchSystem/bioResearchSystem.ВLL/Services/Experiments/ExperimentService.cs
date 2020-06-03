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
      
        private readonly IMapper mapper;
        public ExperimentService(IMapper _mapper)
        {
      
            mapper = _mapper;

        }
    }
}
