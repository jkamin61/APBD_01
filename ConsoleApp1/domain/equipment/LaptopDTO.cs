using ConsoleApp1.domain.equipment;

namespace ConsoleApp1.Domain.Equipment;

public class LaptopDTO : EquipmentDTO
{
    public int RamGb { get; }
    public string Processor { get; }

    public LaptopDTO(int id, string name, int ramGb, string processor)
        : base(id, name)
    {
        RamGb = ramGb;
        Processor = processor;
    }

    public override string ToString()
    {
        return base.ToString() + $" | RAM: {RamGb} GB, CPU: {Processor}";
    }
}