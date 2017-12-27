using api.Models;

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