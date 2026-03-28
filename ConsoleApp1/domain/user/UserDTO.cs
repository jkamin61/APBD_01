namespace ConsoleApp1.Domain.User;

public abstract class UserDTO
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    protected UserDTO(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract int MaxActiveRentals { get; }
    public abstract string UserType { get; }

    public override string ToString()
    {
        return $"[{Id}] {FirstName} {LastName} ({UserType})";
    }
}