using ConsoleApp1.Domain;

namespace ConsoleApp1.service;

public class UserServiceImpl
{
    public User addUser(User user)
    {
        User.AddUser(user);
        return user;
    }
}