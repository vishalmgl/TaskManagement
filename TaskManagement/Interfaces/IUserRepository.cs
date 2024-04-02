using TaskManagement.Model;

namespace TaskManagement.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int UserID);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(User User);
        bool Save();

    }
}
