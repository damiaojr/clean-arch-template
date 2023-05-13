# INFRASTRUCTURE

This layer contains classes for accessing external resources such as databases, web services, file systems, and so on. 

These classes should be based on interfaces defined within the domain layer.

## Project Layers

[/Gateway](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Infrastructure/Gateway/README.md)

[/Persistence](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Infrastructure/Persistence/README.md)

## Entity Framework

Entity Framework is an object-relational mapping (ORM) framework developed by Microsoft for .NET applications. It provides a way to map database tables to CLR (Common Language Runtime) objects, allowing developers to work with data using object-oriented programming techniques instead of directly manipulating database tables.

With Entity Framework, developers can define their database schema using C# or Visual Basic code, and the framework will automatically generate SQL queries to interact with the database. This can simplify development by eliminating the need for repetitive SQL coding and allowing developers to focus on business logic.

Entity Framework also provides features such as change tracking, lazy loading, and caching, which can improve application performance and reduce the amount of code required to interact with the database. Additionally, it supports multiple database providers, making it easy to work with different database engines such as SQL Server, MySQL, and SQLite.

## RestSharp

RestSharp simplifies the process of sending and receiving HTTP requests and responses, by abstracting away the details of low-level HTTP communication, and providing a high-level object-oriented API that allows developers to interact with RESTful services using C# code.

The library supports various HTTP methods and provides features such as request and response headers, query parameters, request and response bodies, and support for serialization and deserialization of objects to and from JSON and XML formats.

RestSharp also supports asynchronous and synchronous requests, and provides several convenience methods for common scenarios such as authentication, file uploads, and handling errors.