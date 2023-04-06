using System.Reflection;
using FluentValidation;
using MediatR;
using OI.Template.Application.Common.Behaviours;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
     public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
     {
          var executingAssembly = Assembly.GetExecutingAssembly();
          
          serviceCollection.AddValidatorsFromAssembly(executingAssembly);
          serviceCollection.AddMediatR(configuration =>
          {
               configuration.RegisterServicesFromAssemblies(executingAssembly);
               configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
               configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
          });

          return serviceCollection;
     }
}