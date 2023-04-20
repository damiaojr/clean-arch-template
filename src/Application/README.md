# APPLICATION

This layer contains the application logic. It handles the CQRS and domain events. 

It is dependent on the domain layer, but has no dependencies on any other layer or project.

The persistence layer is accessed by Domain interfaces.