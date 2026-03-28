using ConsoleApp1.Domain.Rental;

namespace ConsoleApp1.service.rental;

public interface IRentalService
{
    RentalDTO RentEquipment(int userId, int equipmentId, int days);
    RentalDTO ReturnEquipment(int rentalId, DateTime returnDate);
    List<RentalDTO> GetActiveRentalsForUser(int userId);
    List<RentalDTO> GetOverdueRentals(DateTime now);
    List<RentalDTO> GetAll();
}