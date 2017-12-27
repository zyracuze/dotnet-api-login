using api.Models;
using api.Contexts;

namespace api.UnitTest.Contexts
{
  public class StubSuccessUserContext : IUserContext
  {
    public User FindUserByUsernameAndPassword(string username, string hashPassword)
    {
      return new User()
      {
        Id = 1,
        Username = "ploy",
        Displayname = "พลอย"
      };
    }
  }
}