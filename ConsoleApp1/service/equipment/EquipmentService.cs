using ConsoleApp1.domain.equipment;
using ConsoleApp1.Domain.Equipment;

namespace ConsoleApp1.service.equipment;

public class EquipmentService : IEquipmentService
{
    private readonly List<EquipmentDTO> _equipment = new();
    private int _nextId = 1;

    public LaptopDTO AddLaptop(string name, int ramGb, string processor)
    {
        int id = _nextId++;
        LaptopDTO newLaptop = new LaptopDTO(id, name, ramGb, processor);
        _equipment.Add(newLaptop);
        return newLaptop;
    }

    public CameraDTO AddCamera(string name, int resolutionMp, string lensType)
    {
        int id = _nextId++;
        CameraDTO newCamera = new CameraDTO(id, name, resolutionMp, lensType);
        _equipment.Add(newCamera);
        return newCamera;
    }

    public ProjectorDTO AddProjector(string name, int lumens, string resolution)
    {
        int id = _nextId++;
        ProjectorDTO newProjectorDTO = new ProjectorDTO(id, name, lumens, resolution);
        _equipment.Add(newProjectorDTO);
        return newProjectorDTO;
    }

    public EquipmentDTO GetEquipmentById(int id)
    {
        return _equipment.FirstOrDefault(x => x.Id == id)
               ?? throw new Exception($"Equipment with id {id} not found");
    }

    public List<EquipmentDTO> GetAllEquipment()
    {
        return _equipment.ToList();
    }

    public List<EquipmentDTO> GetAllAvailableEquipment()
    {
        return _equipment.Where(e => e.IsAvailable()).ToList();
    }

    public void MarkEquipmentAsBroken(int id)
    {
        GetEquipmentById(id).MarkAsBroken();
    }

    public void MarkEquipmentInService(int id)
    {
        GetEquipmentById(id).MarkAsInService();
    }
}