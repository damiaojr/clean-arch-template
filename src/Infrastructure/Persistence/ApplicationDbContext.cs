using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OI.Template.Domain.Repository;
using OI.Template.Infrastructure.Common;

namespace OI.Template.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IMediator _mediator;
    
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options, 
        IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Domain.Entities.Notification> Notifications => Set<Domain.Entities.Notification>();
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEvents(this);
   
        return await base.SaveChangesAsync(cancellationToken);
    }
}