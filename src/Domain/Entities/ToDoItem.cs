namespace OI.Template.Domain.Entities;

public class ToDoItem : BaseAuditableEntity
{
    public Guid ListId { get; set; }
    public string? Title { get; set; }
    public string? Note { get; set; }
    public ToDoList List { get; set; } = null!;
}