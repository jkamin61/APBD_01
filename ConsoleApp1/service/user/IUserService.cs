using ConsoleApp1.Domain.User;

namespace ConsoleApp1.service.user;

public interface IUserService
{
    UserDTO AddStudent(string firstName, string lastName, string studentNumber);
    UserDTO AddEmployee(string firstName, string lastName, string studentNumber);
    UserDTO GetByid(int ic);
    List<UserDTO> GetAll();
}