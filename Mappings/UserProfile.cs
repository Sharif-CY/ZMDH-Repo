using AutoMapper;
using WDPR.Models;
using WDPR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WDPR.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(dst => dst.Username, opt => opt.MapFrom(x => x.UserName));
            CreateMap<UserViewModel, ApplicationUser>();
        }
    }
}
