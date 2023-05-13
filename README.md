# OI API TEMPLATE

This is project serves as a guideline for API development in Ocean Infinity's Web & Cloud team.

It follows the definitions documented [here](https://oceaninfinity.atlassian.net/wiki/spaces/TECHSWPROD/pages/2042364020/Web+Services+Guideline) for architecture and libraries.

### Solution layers

###### [src/Contract](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Contract/README.md)

- Simple data transfer classes used by multiple parties to integrate with a microservice.
- The main entrypoints (SDK, API and Service layers) reference this.
- Used to isolate external contracts from internal business classes and data objects.
- Can be merged, for simplicity purposes, with the SDK layer.

###### [src/API](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/API/README.md)

- Entry point for HTTP connections.
- Should not have business logic, but can have input/user validations.
- Initializes the other layers (using Dependency Injection) if necessary.
- Calls the Application layer by the use of the Mediatr NuGet (mediator pattern).
- Should never pass Domain classes to external entities (use contracts/sdk).
- Should not create new instances of Domain classes, but can receive them from the Application layer.

###### [src/Service](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Service/README.md)

- Entry point for event processing.
- Should not have business logic, but can have input validations.
- Initializes the other layers (using Dependency Injection) if necessary.
- Calls the Application layer by the use of the Mediatr NuGet (mediator pattern).
- Should never pass Domain classes to external entities (use contracts/sdk).
- Should not create new instances of Domain classes, but can receive them from the Application layer.

###### [src/Application](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Application/README.md)

- Main business flow/logic layer.
- Uses CQRS pattern.
- Should implement IRequestHandler for queries and INotificationHandler for commands.
- Uses classes from Domain layer for data representation. 

###### [src/Domain](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Domain/README.md)

- Simple business representative classes with very minimal logic.
- Should not have any references to other systems.
- Should have interfaces for the repositories. (Domain)IServiceRepository → (Infrastructure)ServiceRepository

###### [src/Infrastructure](https://dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template?path=/src/Infrastructure/README.md)

- Integration layer with other systems, microservices, databases, …
- Can have their own DTOs if necessary. Can use Domain layer classes as “contracts” with the Application layer.

### Code conventions and C# Style Guides

[C# Coding Conventions by Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

Coding conventions serve the following purposes:

- They create a consistent look to the code, so that readers can focus on content, not layout.
- They enable readers to understand the code more quickly by making assumptions based on previous experience.
- They facilitate copying, changing, and maintaining the code.
- They demonstrate C# best practices.

[C# Style Guide by Google](https://google.github.io/styleguide/csharp-style.html)

This style guide is for C# code developed internally at Google, and is the default style for C# code at Google. It makes stylistic choices that conform to other languages at Google, such as Google C++ style and Google Java style.



### .NET Template

A .NET template is a set of files and metadata that describe a new project or project fragment that can be used as a starting point for new .NET projects. There is a custom template for this project and you can install it using the dotnet CLI.

1. Clone the project:
   SSH

   ```bash
   git clone git@ssh.dev.azure.com:v3/OceanInfinity-Group/TECH-SW-EXPERIMENTS/backend-api-template
   ```

   HTTPS

   ```bash
   git clone https://OceanInfinity-Group@dev.azure.com/OceanInfinity-Group/TECH-SW-EXPERIMENTS/_git/backend-api-template
   ```

   

2. Navigate to the project root folder (where the *.sln* file is located).
   

3. Install the template:

   ```bash
   dotnet new --install . 
   ```

4. Check if the template is installed:

   ```bash
   dotnet new list
   ```

   *OI Web Service Template* should be on the list.

5. To use the template, navigate to the desired directory and run:

   ```bash
   dotnet new oi-api-template -o "<my-project-name>"
   ```

   