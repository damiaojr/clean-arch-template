using FluentValidation;
using MediatR;

namespace OI.Template.Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validatorCollection;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validatorCollection)
    {
        _validatorCollection = validatorCollection;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validatorCollection.Any())
        {
            var validationContext = new ValidationContext<TRequest>(request);
            var validationResult = await Task.WhenAll(
                _validatorCollection.Select(validator =>
                    validator.ValidateAsync(validationContext, cancellationToken)));

            var failureCollection = validationResult
                .Where(result => result.Errors.Any())
                .SelectMany(result => result.Errors).ToList();

            if (failureCollection.Any())
            {
                throw new Exceptions.ValidationException(failureCollection);
            }
        }

        return await next();
    }
}