namespace ConsoleApp1.Domain.User;

public class EmployeeDTO : UserDTO
{
    public string Department { get; }

    public EmployeeDTO(int id, string firstName, string lastName, string department)
        : base(id, firstName, lastName)
    {
        Department = department;
    }

    public override int MaxActiveRentals => 5;
    public override string UserType => "Employee";
}