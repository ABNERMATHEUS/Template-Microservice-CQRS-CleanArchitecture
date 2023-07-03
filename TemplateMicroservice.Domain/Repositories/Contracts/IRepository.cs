using TemplateMicroservice.Domain.Entities.Bases;

namespace TemplateMicroservice.Domain.Repositories.Contracts;

public interface IRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    IQueryable<TEntity> Get();
    Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);

    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Create(TEntity entity);
    void CreateArrange(IList<TEntity> entities);
    Task CreateArrangeAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);

    Task BulkInsertAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);
    Task BulkDeleteAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);
    Task BulkUpdateAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);
    void Update(TEntity entity);
    void UpdateArrange(IList<TEntity> entities);

    void Delete(TEntity entity);
    void DeleteArrange(IList<TEntity> entities);

    Task<int> SaveAsync(CancellationToken cancellationToken = default);
    void Save();
}