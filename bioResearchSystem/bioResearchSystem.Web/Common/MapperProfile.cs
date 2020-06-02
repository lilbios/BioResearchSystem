using AutoMapper;
using bioResearchSystem.Models.Entities;
using bioResearchSystem.Web.Models.Accounts;
using bioResearchSystem.Web.Models.Topics;
using bioResearchSystem.Web.Models.Users;
using bioResearchSystem.ВLL.Services.Accounts;
using bioResearchSystem.ВLL.Services.Topics;
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
            CreateMap<RegisterViewModel, UserDTO>().ReverseMap();
            CreateMap<UserDTO, AppUser>().ReverseMap();
            CreateMap<TopicViewModel, TopicDTO>().ReverseMap();
            CreateMap<TopicDTO, Topic>().ReverseMap();
            CreateMap<LoginedUserViewModel, UserDTO>().ReverseMap();
            CreateMap<UserDTO,AppUser>().ReverseMap();
            CreateMap<AppUser, ProfileViewModel>().ReverseMap();
            CreateMap<UserDTO, ProfileViewModel>().ReverseMap();
            
           



        }
    }
}
