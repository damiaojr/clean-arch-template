using MediatR;
using Microsoft.Extensions.Logging;

namespace OI.Template.Application.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            //ToDo: Filter exceptions that we don't want to log
            
            var requestName = typeof(TRequest).Name;
            
            _logger.LogError(exception, "Request Error: Unhandled exception for {Name} {@Request}", requestName, request);

            throw;
        }
    }
}