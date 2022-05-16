using AdoptApi.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AdoptApi.Models.Interceptors;

public class SoftDeletableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        HandleSoftDeletes(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        HandleSoftDeletes(eventData.Context);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void HandleSoftDeletes(DbContext? context)
    {
        if (context == null)
        {
            return;
        }
        var changedEntries = context.ChangeTracker.Entries<ISoftDeletable>().Where(entity => entity.State is EntityState.Added or EntityState.Deleted);
        foreach (var changedEntry in changedEntries)
        {
            var deletedProp = changedEntry.Property(prop => prop.DeletedOn);
            switch (changedEntry.State)
            {
                case EntityState.Added:
                    deletedProp.CurrentValue = null;
                    break;
                case EntityState.Deleted:
                    deletedProp.CurrentValue = DateTime.Now;
                    deletedProp.IsModified = true;
                    changedEntry.State = EntityState.Modified;
                    break;
            }
        }
    }
}