namespace TemplateMicroservice.Domain.Entities.Bases;

public abstract class BaseEntity<T>
{
    protected BaseEntity()
    {
    }


    protected BaseEntity(T id, string createdBy)
    {
        Id = id;
        CreatedBy = createdBy;
    }

    public BaseEntity(T id, DateTime createAt, string createdBy, string? updatedBy, DateTime? updateAt)
    {
        Id = id;
        CreatedAt = createAt;
        UpdatedAt = updateAt;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
    }

    public T Id { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public string? UpdatedBy { get; }

    public void AddCreatedAt(DateTime dateTime)
    {
        CreatedAt = dateTime;
    }

    public void AddUpdatedAt(DateTime dateTime)
    {
        UpdatedAt = dateTime;
    }
}