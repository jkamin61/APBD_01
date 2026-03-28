using ConsoleApp1.domain.equipment;
using ConsoleApp1.Domain.Equipment;

namespace ConsoleApp1.service.equipment;

public interface IEquipmentService
{
    public LaptopDTO AddLaptop(string name, int ramGb, string processor);
    public CameraDTO AddCamera(string name, int resolutionMp, string lensType);
    public ProjectorDTO AddProjector(string name, int lumens, string resolution);
    public EquipmentDTO GetEquipmentById(int id);
    public List<EquipmentDTO> GetAllEquipment();
    public List<EquipmentDTO> GetAllAvailableEquipment();
    public void MarkEquipmentAsBroken(int id);
    public void MarkEquipmentInService(int id);
}