using Ecoinmerce.Domain.Entities;
using Ecoinmerce.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Ecoinmerce.Infra.Respository.Database.Context;

public class BaseContext : DbContext
{
    protected IHttpContextAccessor HttpContextAccessor { get; }
    public BaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        this.HttpContextAccessor = httpContextAccessor;
    }


    public override int SaveChanges()
    {
        SetTimestampsAndAgents();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        SetTimestampsAndAgents();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        SetTimestampsAndAgents();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestampsAndAgents();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestampsAndAgents()
    {
        IEnumerable<EntityEntry> entities = ChangeTracker.Entries()
            .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

        foreach (EntityEntry entity in entities)
        {
            if (entity.Entity is IBaseTimestampEntity entityTimestamp)
            {
                AddTimestamps(entityTimestamp, entity.State == EntityState.Added);

            }
            if (entity.Entity is IBaseAgentEntity entityAgent)
            {
                AddAgents(entityAgent, entity.State == EntityState.Added);
            }
        }
    }
    private static void AddTimestamps(IBaseTimestampEntity entity, bool wasAdded)
    {
        var now = DateTime.Now;

        if (wasAdded)
        {
            entity.CreatedAt = now;
        }
        entity.UpdatedAt = now;
    }

    private void AddAgents(IBaseAgentEntity entity, bool wasAdded)
    {
        EcommerceAdmin admin = (EcommerceAdmin)HttpContextAccessor.HttpContext.Items["Admin"];
        EcommerceManager customer = (EcommerceManager)HttpContextAccessor.HttpContext.Items["Manager"];

        string agent = admin == null ? (customer == null ? "ANONYMOUS" : customer.Email) : admin.Username;

        if (wasAdded)
        {
            entity.CreatedBy = agent;
        }
        entity.UpdatedBy = agent;
    }
}
