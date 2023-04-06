using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Events;

public class ToDoItemDeletedEvent : BaseEvent
{
    public ToDoItemDeletedEvent(ToDoItem item)
    {
        Item = item;
    }
    
    public ToDoItem Item { get; }
}