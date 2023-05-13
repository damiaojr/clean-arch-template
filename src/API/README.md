# API

An API (Application Programming Interface) is a set of rules, protocols, and tools that allow software applications to communicate with each other. APIs define how software components should interact, specifying the types of requests and responses that can be sent and received.

APIs can be internal or external to an organization, and they can be used to enable integration between different systems, services, or applications. For example, an API can be used by a web application to retrieve data from a database, or by a mobile application to access cloud-based services.

APIs can be implemented in many different ways, such as REST (Representational State Transfer), SOAP (Simple Object Access Protocol), and GraphQL. They can be designed for specific purposes, such as data access, authentication, or messaging.

*The communication with the application layer must be done using [Mediatr](https://github.com/jbogard/MediatR) and it should only expose **Contract** classes.*

## MediatR

MediatR is a popular open-source library for implementing the mediator pattern in .NET applications. The mediator pattern is a design pattern that promotes loose coupling between components by allowing them to communicate through a mediator object, instead of directly invoking each other's methods.

In MediatR, the mediator object is called `IMediator`, and it provides a simple interface for sending and receiving messages between components. The messages are represented as C# objects, which are referred to as requests and notifications.

Here's a simple example of using MediatR:

```c#
// Define a request class
public class MyRequest : IRequest<int> {
    public int Number { get; set; }
}

// Define a handler class for the request
public class MyRequestHandler : IRequestHandler<MyRequest, int> {
    public Task<int> Handle(MyRequest request, CancellationToken cancellationToken) {
        int result = request.Number * 2;
        return Task.FromResult(result);
    }
}

// Set up the MediatR service
var services = new ServiceCollection();
services.AddMediatR(typeof(MyRequestHandler).Assembly);

// Resolve the MediatR service
var mediator = services.BuildServiceProvider().GetRequiredService<IMediator>();

// Send a request and get the result
int response = await mediator.Send(new MyRequest { Number = 42 });
Console.WriteLine(response); // Output: 84

```

## AutoMapper

AutoMapper is an open-source library for mapping data between different objects in .NET applications. It provides a convenient and flexible way to convert data from one format to another without having to write a lot of boilerplate code.

In AutoMapper, the mapping configuration is defined using profiles, which specify how to map properties between different classes. The library uses reflection to automatically map properties with matching names and types, but it also allows for custom mappings and transformations.

Here's a simple example of using AutoMapper:

```c#
// Define the source and destination classes
public class SourceClass {
    public int Id { get; set; }
    public string Name { get; set; }
}

public class DestinationClass {
    public int Identifier { get; set; }
    public string FullName { get; set; }
}

// Create a mapping profile
public class MappingProfile : Profile {
    public MappingProfile() {
        CreateMap<SourceClass, DestinationClass>()
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name));
    }
}

// Configure AutoMapper
var mapperConfiguration = new MapperConfiguration(cfg => {
    cfg.AddProfile<MappingProfile>();
});

// Create a mapper instance
var mapper = mapperConfiguration.CreateMapper();

// Map an object from the source class to the destination class
var sourceObject = new SourceClass { Id = 1, Name = "John Smith" };
var destinationObject = mapper.Map<DestinationClass>(sourceObject);

// Output the mapped object
Console.WriteLine(destinationObject.Identifier); // Output: 1
Console.WriteLine(destinationObject.FullName); // Output: John Smith

```

