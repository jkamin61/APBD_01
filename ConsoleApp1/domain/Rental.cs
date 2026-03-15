namespace ConsoleApp1.Domain;

public class Rental(
    User user,
    Equipment rentedEquipment,
    DateTime returnDate,
    DateTime rentDate,
    DateTime actualReturnDate,
    double fees,
    double additionalFees)
{
    public DateTime ReturnDate { get; private set; } = returnDate;
    public DateTime RentDate { get; private set; } = rentDate;
    public DateTime ActualReturnDate { get; private set; } = actualReturnDate;
    public double Fees { get; private set; } = fees;
    public double AdditionalFees { get; private set; } = additionalFees;

    private static TimeSpan GetRentalDuration(DateTime rentDate, DateTime returnDate)
    {
        return (returnDate - rentDate);
    }

    public bool wasReturnedOnTime(DateTime rentDate, DateTime actualReturnDate, DateTime returnDate)
    {
        var diff = actualReturnDate - rentDate;
        if (diff <= GetRentalDuration(returnDate, returnDate)) return true;
        Console.WriteLine("Exceeded {0} days", diff.TotalDays);
        return false;
    }
}