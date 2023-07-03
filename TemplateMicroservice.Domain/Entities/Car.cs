using TemplateMicroservice.Domain.Entities.Bases;
using TemplateMicroservice.Domain.Enums;

namespace TemplateMicroservice.Domain.Entities;

public sealed class Car : BaseEntity<Guid>
{
    private Car()
    {
    }

    public Car(Guid id,
        string createdBy,
        string name, string
            color, string model,
        EEntityStatus status) : base(id, createdBy)
    {
        Id = id;
        Name = name;
        Color = color;
        Model = model;
        Status = status;
    }


    public string Name { get; private set; }
    public string Color { get; private set; }
    public string Model { get; private set; }

    public EEntityStatus Status { get; private set; }

    public void Update(string color, string model, string name)
    {
        Color = color;
        Model = model;
        Name = name;
        AddUpdatedAt(DateTime.Now);
    }
}