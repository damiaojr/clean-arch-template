using FluentValidation;

namespace OI.Template.Application.ToDoList.Commands.CreateToDoList;

public class CreateToDoListCommandValidator : AbstractValidator<CreateToDoListCommand>
{
    public CreateToDoListCommandValidator()
    {
        RuleFor(entity => entity.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");
    }
}