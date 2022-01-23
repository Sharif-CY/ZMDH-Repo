using AutoMapper;
using WDPR.Helpers;
using WDPR.Models;
using WDPR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WDPR.Mappings
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageViewModel>()
                .ForMember(dst => dst.From, opt => opt.MapFrom(x => x.FromUser.FullName))
                .ForMember(dst => dst.To, opt => opt.MapFrom(x => x.ToRoom.Name))
                .ForMember(dst => dst.Avatar, opt => opt.MapFrom(x => x.FromUser.Avatar))
                .ForMember(dst => dst.Timestamp, opt => opt.MapFrom(x => x.Timestamp));
            CreateMap<MessageViewModel, Message>();
        }
    }
}
