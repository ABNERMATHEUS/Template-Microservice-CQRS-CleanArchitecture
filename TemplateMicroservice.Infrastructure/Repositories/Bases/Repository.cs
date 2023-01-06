using TemplateMicroservice.Core.Entities.Bases;
using TemplateMicroservice.Core.Repositories.Contracts;
using TemplateMicroservice.Infrastructure.Context;

namespace TemplateMicroservice.Infrastructure.Repositories.Bases;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    protected Repository(DbContextTemplateMicroservice dbContext)
    {
        _DbContext = dbContext;
    }

    private DbContextTemplateMicroservice _DbContext { get; set; }


    #region READ

    public virtual IQueryable<TEntity> Get()
    {
        return _DbContext.Set<TEntity>();
    }

    #endregion

    #region CREATE

    public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.AddCreatedAt(DateTime.Now);
        await _DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
    }

    public virtual void Create(TEntity entity)
    {
        entity.AddCreatedAt(DateTime.Now);
        _DbContext.Set<TEntity>().Add(entity);
    }

    public virtual void CreateArrange(IList<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.AddUpdatedAt(DateTime.Now);
        }

        _DbContext.Set<TEntity>().AddRange(entities);
    }

    public virtual async Task CreateArrangeAsync(IList<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            entity.AddUpdatedAt(DateTime.Now);
        }

        await _DbContext.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
    }

    #endregion

    #region UPDATE

    public virtual void Update(TEntity entity)
    {
        entity.AddUpdatedAt(DateTime.Now);
        _DbContext.Set<TEntity>().Update(entity);
    }

    public virtual void UpdateArrange(IList<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.AddUpdatedAt(DateTime.Now);
        }

        _DbContext.Set<TEntity>().UpdateRange(entities);
    }

    #endregion

    #region DELETE

    public virtual void Delete(TEntity entity)
    {
        _DbContext.Set<TEntity>().Remove(entity);
    }

    public virtual void DeleteArrange(IList<TEntity> entities)
    {
        _DbContext.Set<TEntity>().RemoveRange(entities);
    }

    #endregion

    #region SAVE

    public virtual async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await _DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual void Save()
    {
        _DbContext.SaveChanges();
    }

    #endregion
}