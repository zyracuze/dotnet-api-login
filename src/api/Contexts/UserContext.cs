using Microsoft.EntityFrameworkCore;
using System.Linq;
using api.Models;
using api.Exceptions;
using api.Contexts;


namespace api.Contexts
{
    public class UserContext : DbContext, IUserContext
    {
        public UserContext(DbContextOptions<UserContext> dbContextOptions) :
            base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; }

        public User FindUserByUsernameAndPassword(string username, string hashPassword){
          try
          {
              return this.Users.Where(u => u.Username == username && u.Password == hashPassword).First();
          }
          catch (System.Exception)
          {    
              throw new UserNotFoundException("Wrong username or password");
          }
        }
    }
}