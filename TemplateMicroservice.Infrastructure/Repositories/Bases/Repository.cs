using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using TemplateMicroservice.Domain.Entities.Bases;
using TemplateMicroservice.Domain.Repositories.Contracts;
using TemplateMicroservice.Infrastructure.Context;

namespace TemplateMicroservice.Infrastructure.Repositories.Bases;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    public Repository(DbContextTemplateMicroservice dbContext)
    {
        _DbContext = dbContext;
    }

    protected DbContextTemplateMicroservice _DbContext { get; set; }


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

    public virtual async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return await _DbContext.SaveChangesAsync(cancellationToken);
    }

    public virtual void Save()
    {
        _DbContext.SaveChanges();
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        return await Get().FirstOrDefaultAsync(x=> x.Id == Id, cancellationToken);
    }

    public async Task BulkInsertAsync(IList<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _DbContext.BulkInsertAsync(entities, cancellationToken:cancellationToken);
    }

    public async Task BulkDeleteAsync(IList<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _DbContext.BulkDeleteAsync(entities, cancellationToken:cancellationToken);
    }

    public async Task BulkUpdateAsync(IList<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _DbContext.BulkUpdateAsync(entities, cancellationToken: cancellationToken);
    }

    #endregion
}