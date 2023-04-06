# API

The entry point layer for HTTP connections.

It should not have any business logic, but can have input validations. It also initializes the other layers using dependency injection.

The communication with the application layer must be done using [Mediatr](https://github.com/jbogard/MediatR) and it should only expose DTO classes.