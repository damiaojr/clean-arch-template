using AutoMapper;
using OI.Template.Application.Notification.Commands.SendPushNotification;

namespace OI.Template.Application.Common.Mapping;

public class NotificationMappingProfile : Profile
{
    public NotificationMappingProfile()
    {
        CreateMap<PushNotificationCommand, Domain.Entities.Notification>()
            .ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Title));
    }
}