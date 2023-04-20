using Microsoft.EntityFrameworkCore;
using OI.Template.Domain.Entities;

namespace OI.Template.Domain.Repository;

public interface IApplicationDbContext
{
    DbSet<Notification> Notifications { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}