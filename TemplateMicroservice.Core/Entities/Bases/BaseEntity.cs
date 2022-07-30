namespace TemplateMicroservice.Core.Entities.Bases;

public abstract class BaseEntity<T>
{
    public BaseEntity(T id, DateTime createAt, string createdBy, string? updatedBy, DateTime? updateAt)
    {
        Id = id;
        CreateAt = createAt;
        UpdateAt = updateAt;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
    }

    public T Id { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public string CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

}