namespace ConsoleApp1.Domain;

public class Rental(
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
}