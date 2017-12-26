using Microsoft.EntityFrameworkCore;
using System.Linq;
using api.Models;
using api.Exceptions;

namespace api.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }

        public User FindUserByUsernameAndPassword(string username, string hashPassword){
          try
          {
              return this.Users.Single(u => u.Username == username && u.Password == hashPassword);
          }
          catch (System.Exception)
          {    
              throw new UserNotFoundException("Wrong username or password");
          }
        }
    }
}