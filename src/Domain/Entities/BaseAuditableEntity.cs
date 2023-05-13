namespace OI.Template.Domain.Entities;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; } = new DateTime().ToUniversalTime();
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}