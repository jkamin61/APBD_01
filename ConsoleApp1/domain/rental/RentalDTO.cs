using ConsoleApp1.domain.equipment;
using ConsoleApp1.Domain.User;

namespace ConsoleApp1.Domain.Rental;

public class RentalDTO
{
    public int Id { get; }
    public UserDTO User { get; }
    public EquipmentDTO Equipment { get; }
    public DateTime RentedAt { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnedAt { get; private set; }
    public decimal PenaltyFee { get; private set; }

    public RentalDTO(int id, UserDTO user, EquipmentDTO equipment, DateTime rentedAt, DateTime dueDate)
    {
        Id = id;
        User = user;
        Equipment = equipment;
        RentedAt = rentedAt;
        DueDate = dueDate;
        ReturnedAt = null;
        PenaltyFee = 0m;
    }

    public bool IsActive()
    {
        return ReturnedAt == null;
    }

    public bool IsOverdue(DateTime now)
    {
        return IsActive() && now > DueDate;
    }

    public bool WasReturnedLate()
    {
        return ReturnedAt.HasValue && ReturnedAt.Value > DueDate;
    }

    public void Return(DateTime returnedAt, decimal penaltyFee)
    {
        if (ReturnedAt != null)
        {
            throw new InvalidOperationException("This rental has already been returned.");
        }

        ReturnedAt = returnedAt;
        PenaltyFee = penaltyFee;
    }

    public override string ToString()
    {
        string status = IsActive() ? "Active" : $"Returned ({ReturnedAt:yyyy-MM-dd})";
        return
            $"Rental[{Id}] User: {User.FirstName} {User.LastName}, Equipment: {Equipment.Name}, Due: {DueDate:yyyy-MM-dd}, Status: {status}, Penalty: {PenaltyFee}";
    }
}