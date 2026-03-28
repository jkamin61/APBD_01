using ConsoleApp1.Domain.Rental;
using ConsoleApp1.service.equipment;
using ConsoleApp1.service.rental;
using ConsoleApp1.utils.enums;

namespace ConsoleApp1.service.report;

public class ReportService : IReportService
{
    private readonly IEquipmentService _equipmentService;
    private readonly IRentalService _rentalService;

    public ReportService(IEquipmentService equipmentService, IRentalService rentalService)
    {
        _equipmentService = equipmentService;
        _rentalService = rentalService;
    }

    public RentalReportSummaryDTO GenerateSummary()
    {
        var equipment = _equipmentService.GetAllEquipment();
        var rentals = _rentalService.GetAll();

        return new RentalReportSummaryDTO()
        {
            TotalEquipment = equipment.Count,
            AvailableEquipment = equipment.Count(e => e.Status == EquipmentStatus.Available),
            RentedEquipment = equipment.Count(e => e.Status == EquipmentStatus.Rented),
            BrokenEquipment = equipment.Count(e => e.Status == EquipmentStatus.Broken),
            InServiceEquipment = equipment.Count(e => e.Status == EquipmentStatus.InService),
            ActiveRentals = rentals.Count(r => r.IsActive()),
            OverdueRentals = rentals.Count(r => r.IsOverdue(DateTime.Now))
        };
    }
}