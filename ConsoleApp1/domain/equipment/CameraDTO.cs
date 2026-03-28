using ConsoleApp1.domain.equipment;

namespace ConsoleApp1.Domain.Equipment;

public class CameraDTO : EquipmentDTO
{
    public int ResolutionMp { get; }
    public string LensType { get; }

    public CameraDTO(int id, string name, int resolutionMp, string lensType)
        : base(id, name)
    {
        ResolutionMp = resolutionMp;
        LensType = lensType;
    }

    public override string ToString()
    {
        return base.ToString() + $" | {ResolutionMp} MP, Lens: {LensType}";
    }
}