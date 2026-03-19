namespace ConsoleApp1.Domain;

public class User(string firstName, string lastName, string role)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string Role { get; private set; } = role;
    private static List<User> Users { get; } = [];

    public static User AddUser(User user)
    {
        Users.Add(user);
        return user;
    }
}