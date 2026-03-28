using ConsoleApp1.utils.enums;

namespace ConsoleApp1.domain.equipment;

public abstract class EquipmentDTO
{
    public int Id { get; }
    public string Name { get; }
    public EquipmentStatus Status { get; private set; }

    protected EquipmentDTO(int id, string name)
    {
        Id = id;
        Name = name;
        Status = EquipmentStatus.Available;
    }

    public bool IsAvailable()
    {
        return Status == EquipmentStatus.Available;
    }

    public void MarkAsAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void MarkAsRented()
    {
        Status = EquipmentStatus.Rented;
    }

    public void MarkAsBroken()
    {
        Status = EquipmentStatus.Broken;
    }

    public void MarkAsInService()
    {
        Status = EquipmentStatus.InService;
    }

    public override string ToString()
    {
        return $"[{Id}] {Name} - {Status}";
    }
}