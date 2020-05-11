using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Web.Models.Accounts;
using bioResearchSystem.ВLL.Services.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bioResearchSystem.Web.Common
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterViewModel, UserDTO>();
            CreateMap<UserDTO, AppUser>();
        }
    }
}
