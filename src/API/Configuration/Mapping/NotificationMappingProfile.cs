using AutoMapper;
using OI.Template.Application.Notification.Commands.SendPushNotification;

namespace OI.Template.API.Configuration.Mapping;

public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<OI.Template.Contract.Notification, PushNotificationCommand>()
            .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Title));
        
        CreateMap<OI.Template.Domain.Entities.Notification, OI.Template.Contract.Notification>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title,
                opt => opt.MapFrom(src => src.Title));
    }
}