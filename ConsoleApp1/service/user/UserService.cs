using ConsoleApp1.Domain.User;

namespace ConsoleApp1.service.user;

public class UserService : IUserService
{
    private readonly List<UserDTO> _users = new();
    private int _nextId = 1;

    public UserDTO AddStudent(string firstName, string lastName, string studentNumber)
    {
        int id = _nextId++;
        var student = new StudentDTO(id, firstName, lastName, studentNumber);
        _users.Add(student);
        return student;
    }

    public UserDTO AddEmployee(string firstName, string lastName, string studentNumber)
    {
        int id = _nextId++;
        var employee = new EmployeeDTO(id, firstName, lastName, studentNumber);
        _users.Add(employee);
        return employee;
    }

    public UserDTO GetByid(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id) ?? throw new Exception($"User with id {id} not found.");
    }

    public List<UserDTO> GetAll()
    {
        return _users.ToList();
    }
}