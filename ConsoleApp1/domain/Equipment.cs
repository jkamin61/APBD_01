namespace ConsoleApp1.Domain;

public class Equipment(string name, string description)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public bool IsStocked { get; private set; } = false;
    public string description { get; private set; } = description;
}