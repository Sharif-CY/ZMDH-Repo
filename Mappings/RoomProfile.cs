using AutoMapper;
using WDPR.Models;
using WDPR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WDPR.Mappings
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
        }
    }
}
