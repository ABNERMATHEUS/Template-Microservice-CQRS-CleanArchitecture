using TemplateMicroservice.Core.Entities.Bases;
using TemplateMicroservice.Core.Enums;

namespace TemplateMicroservice.Core.Entities;

public class Car : BaseEntity<Guid>
{
    public Car()
    {
    }

    public Car(Guid id,
        DateTime createdAt,
        string createdBy,
        string name, string
        color, string model,
        EEntityStatus status) : base(id, createdAt, createdBy, null, null)
    {
        Name = name;
        Color = color;
        Model = model;
        Status = status;
    }


    public string Name { get; set; }
    public string Color { get; set; }
    public string Model { get; set; }
    
    public EEntityStatus Status { get; set; }

}