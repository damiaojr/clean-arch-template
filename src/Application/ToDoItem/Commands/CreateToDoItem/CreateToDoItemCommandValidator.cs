using FluentValidation;

namespace OI.Template.Application.ToDoItem.Commands.CreateToDoItem;

public class CreateToDoItemCommandValidator : AbstractValidator<CreateToDoItemCommand>
{
    public CreateToDoItemCommandValidator()
    {
        RuleFor(entity => entity.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}