namespace ConsoleApp1.Domain.Rental;

public class RentalReportSummaryDTO
{
    public int TotalEquipment { get; set; }
    public int AvailableEquipment { get; set; }
    public int RentedEquipment { get; set; }
    public int BrokenEquipment { get; set; }
    public int InServiceEquipment { get; set; }
    public int ActiveRentals { get; set; }
    public int OverdueRentals { get; set; }
}