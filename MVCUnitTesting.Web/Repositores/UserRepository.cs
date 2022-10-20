using MVCUnitTesting.Web.BD;
using MVCUnitTesting.Web.Models;
// ReSharper disable All

namespace MVCUnitTesting.Web.Repositores;

public interface IUserRepository
{
    List<User> GetAll();
    User Find(int id);
    User Create(User user);
}

public class UserRepository: IUserRepository
{

    private static List<User> USER_DB = new()
    {
        new User {Id = 1, Name = "Luis"},
        new User {Id = 2, Name = "Andres"},
        new User {Id = 3, Name = "Martin"},
    };

    // private DbEntities context;
    // public UserRepository(/*DbEntities context*/)
    // {
        // this.context = context;
    // }
    
    public List<User> GetAll()
    {
        return USER_DB;
    }

    public User Find(int id)
    {
        return USER_DB
            .Where(o => o.Id == id)
            .FirstOrDefault()!;
    }

    public User Create(User user)
    {
        user.Id = USER_DB.Max(x => x.Id) + 1;
        USER_DB.Add(user);
        return user;
    }
}