using ConsoleApp1.domain.equipment;
using ConsoleApp1.Domain.Rental;
using ConsoleApp1.Domain.User;
using ConsoleApp1.service.equipment;
using ConsoleApp1.service.user;

namespace ConsoleApp1.service.rental;

public class RentalService : IRentalService
{
    private readonly IUserService _userService;
    private readonly IEquipmentService _equipmentService;
    private readonly List<RentalDTO> _rentals = new();
    private int _nextId = 1;
    private const decimal DailyPenalty = 10m;

    public RentalService(IUserService userService, IEquipmentService equipmentService)
    {
        _userService = userService;
        _equipmentService = equipmentService;
    }

    public RentalDTO RentEquipment(int userId, int equipmentId, int days)
    {
        UserDTO user = _userService.GetByid(userId);
        EquipmentDTO equipment = _equipmentService.GetEquipmentById(equipmentId);
        if (!equipment.IsAvailable())
        {
            throw new Exception("Equipment not available.");
        }

        int activeRentalsCount = _rentals.Count(r => r.User.Id == userId && r.IsActive());
        if (activeRentalsCount >= user.MaxActiveRentals)
        {
            throw new Exception($"User exceeded rental limit ({user.MaxActiveRentals}).");
        }

        var now = DateTime.Now;
        var rental = new RentalDTO(_nextId++, user, equipment, now, now.AddDays(days));

        equipment.MarkAsRented();
        _rentals.Add(rental);

        return rental;
    }

    public RentalDTO ReturnEquipment(int rentalId, DateTime returnDate)
    {
        RentalDTO rental = _rentals.FirstOrDefault(r => r.Id == rentalId) ??
                           throw new Exception($"Rental with id {rentalId} not found.");
        if (!rental.IsActive())
        {
            throw new Exception("Rental not available.");
        }

        decimal penalty = CalculatePenalty(rental, returnDate);
        rental.Return(returnDate, penalty);
        rental.Equipment.MarkAsAvailable();

        return rental;
    }

    public List<RentalDTO> GetActiveRentalsForUser(int userId)
    {
        return _rentals
            .Where(r => r.User.Id == userId && r.IsActive())
            .ToList();
    }

    public List<RentalDTO> GetOverdueRentals(DateTime now)
    {
        return _rentals
            .Where(r => r.IsOverdue(now))
            .ToList();
    }

    public List<RentalDTO> GetAll()
    {
        return _rentals.ToList();
    }

    private decimal CalculatePenalty(RentalDTO rental, DateTime returnDate)
    {
        if (returnDate <= rental.DueDate)
        {
            return 0m;
        }

        int lateDays = (returnDate.Date - rental.DueDate.Date).Days;
        return lateDays * DailyPenalty;
    }
}