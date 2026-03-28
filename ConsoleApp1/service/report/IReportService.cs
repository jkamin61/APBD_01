using ConsoleApp1.Domain.Rental;

namespace ConsoleApp1.service.report;

public interface IReportService
{
    RentalReportSummaryDTO GenerateSummary();
}