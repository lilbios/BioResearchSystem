using AutoMapper;
using bioResearchSystem.API.Models;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.ВLL.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.API.Common
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<RegisterViewModel, UserDTO>().ReverseMap();
            CreateMap<LoginViewModel, UserDTO>().ReverseMap();
            CreateMap<UserDTO, AppUser>().ReverseMap();
        }
    }
}
