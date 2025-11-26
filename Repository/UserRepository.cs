using Entities;
using Repository.Models;
using System.Text.Json;
namespace Repository
{
    public class UserRepository : IUserRepository
    {

        MyWebApiShopContext _context;
        public UserRepository(MyWebApiShopContext context)
        {
            _context = context;
        }

        public User GetUserById(int id)
        {
            User? user = _context.Users.Find(id);
            return user;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User LoginUser(User loginUser)
        {
            User? user = _context.Users
                .FirstOrDefault(u => u.UserEmail == loginUser.UserEmail && u.UserPassword == loginUser.UserPassword);
            return user;
        }

        public void UpdateUser(int id, User myUser)
        {
            User user1 = _context.Users.Find(id);
            if (user1 != null)
            {
                user1.UserEmail = myUser.UserEmail;
                user1.UserFirstName = myUser.UserFirstName;
                user1.UserLastName = myUser.UserLastName;
                user1.UserPassword = myUser.UserPassword;
                _context.SaveChanges();
            }
        }


    }
}
