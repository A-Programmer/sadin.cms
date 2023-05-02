using Sadin.Cms.Domain.Primitives;

namespace Sadin.Cms.Persistence.EntityConfigurations.Base;

public abstract class EntityMapBase<TEntity> : IEntityMap<TEntity> where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}