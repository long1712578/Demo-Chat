using AutoMapper;
using System.Collections.Generic;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.Widgets;

namespace TMT.TDeskApp
{
    public class TDeskAppApplicationAutoMapperProfile : Profile
    {
        public TDeskAppApplicationAutoMapperProfile()
        {
            CreateMap<Message, MessageDto>();
            CreateMap<UpdateMessageDto, Message>();
            CreateMap<Widget, WidgetDto>();
        }
    }
}
