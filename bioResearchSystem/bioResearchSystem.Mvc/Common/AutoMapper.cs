using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Mvc.Models.Accounts;
using bioResearchSystem.ВLL.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Mvc.Common
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<RegisterViewModel, UserDTO>().ReverseMap();
            CreateMap<LoginViewModel, UserDTO>().ReverseMap();
            CreateMap<UserDTO, AppUser>().ReverseMap();
        }
    }
}
