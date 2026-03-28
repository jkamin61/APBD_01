using ConsoleApp1.domain.equipment;

namespace ConsoleApp1.Domain.Equipment;

public class ProjectorDTO : EquipmentDTO
{
    public int Lumens { get; }
    public string Resolution { get; }

    public ProjectorDTO(int id, string name, int lumens, string resolution)
        : base(id, name)
    {
        Lumens = lumens;
        Resolution = resolution;
    }

    public override string ToString()
    {
        return base.ToString() + $" | {Lumens} lm, Res: {Resolution}";
    }
}