//using Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System.Text.Json;

namespace Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly MyWebApiShopContext _context;
        public UserRepository(MyWebApiShopContext context)
        {
            _context = context;
        }

        async public Task<User> GetUserById(int id)
        {
            User? user = await _context.Users.FindAsync(id);
            return user;
        }

        async public Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        async public Task<User> LoginUser(User loginUser)
        {
            User? user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == loginUser.Email && u.Password == loginUser.Password);
            return user;
        }

        async public Task UpdateUser(int id, User myUser)
        {
            User user1 = await _context.Users.FindAsync(id);
            if (user1 != null)
            {
                user1.Email = myUser.Email;
                user1.FirstName = myUser.FirstName;
                user1.LastName = myUser.LastName;
                user1.Password = myUser.Password;
                await _context.SaveChangesAsync();
            }
        }


    }
}
