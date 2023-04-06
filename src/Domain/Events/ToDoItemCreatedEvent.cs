using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Events;

public class ToDoItemCreatedEvent : BaseEvent
{
    public ToDoItemCreatedEvent(ToDoItem item)
    {
        Item = item;
    }

    public ToDoItem Item { get; }
}