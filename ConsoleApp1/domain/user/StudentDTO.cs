namespace ConsoleApp1.Domain.User;

public class StudentDTO : UserDTO
{
    public string StudentNumber { get; }

    public StudentDTO(int id, string firstName, string lastName, string studentNumber)
        : base(id, firstName, lastName)
    {
        StudentNumber = studentNumber;
    }

    public override int MaxActiveRentals => 2;
    public override string UserType => "Student";
}