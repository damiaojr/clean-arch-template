using FluentValidation;

namespace OI.Template.Application.Notification.Commands.SendPushNotification;

public class PushNotificationCommandValidator : AbstractValidator<PushNotificationCommand>
{
    public PushNotificationCommandValidator()
    {
        RuleFor(command => command.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(10).WithMessage("Title must not exceed 10 characters");
    }
}