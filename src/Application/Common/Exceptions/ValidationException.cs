using FluentValidation.Results;
namespace OI.Template.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public IDictionary<string, string[]> Errors { get; set; }
    
    public ValidationException() : base("One or more validation failures have occured.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(IEnumerable<ValidationFailure> failures)
    {
        Errors = failures
            .GroupBy(exception => exception.PropertyName, exception => exception.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }
}