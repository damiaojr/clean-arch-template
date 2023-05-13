# DOMAIN

The domain layer contains the core logic and rules that govern the behavior of the application.

This will contain all entities, enums, exceptions, types and logic specific to the domain.

It should not reference other projects.

## Entities

An entity is a data object that represents a real-world object or concept within a domain. It is a basic building block of object-oriented programming and is used to encapsulate data and behavior related to a specific concept or object.

Entities typically have unique identifiers, such as primary keys in a database, that allow them to be uniquely identified and retrieved. They may also have properties and methods that define their behavior and functionality.

In domain-driven design, entities are a key part of the domain model and represent the core objects and concepts that the system deals with. They encapsulate the behavior and rules that govern the domain and provide a rich abstraction that allows the system to be more easily adapted to changing requirements over time.

## Events

An event is a signal that indicates that something has happened, such as a user input, a change in state, or an error condition. Events can be used to trigger actions or to notify other parts of the program that something has occurred.

Events are a key part of event-driven programming, where the flow of control in the program is determined by events rather than by explicit program flow. In event-driven programming, the program waits for events to occur and responds to them as they happen, rather than executing a fixed sequence of instructions.

In order to handle events, a program typically defines event handlers, which are functions or methods that are executed in response to specific events. Event handlers are registered with the system or framework that generates the events, and are called automatically when the corresponding event occurs.

```c#
using System;

class Program
{
    public delegate void MyEventHandler(object sender, MyEventArgs e);

    public static event MyEventHandler MyEvent;

    static void Main(string[] args)
    {
        MyEvent += new MyEventHandler(MyEventHandlerMethod);
        RaiseMyEvent();
    }

    static void MyEventHandlerMethod(object sender, MyEventArgs e)
    {
        Console.WriteLine("Event raised at {0} with message: {1}", e.EventTime, e.Message);
    }

    static void RaiseMyEvent()
    {
        MyEventArgs e = new MyEventArgs("Hello World!");
        e.EventTime = DateTime.Now;
        MyEvent(null, e);
    }
}

public class MyEventArgs : EventArgs
{
    public MyEventArgs(string message)
    {
        this.Message = message;
    }

    public string Message { get; set; }
    public DateTime EventTime { get; set; }
}
```

