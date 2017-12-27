using api.Models;
using api.Services;

namespace api.UnitTest
{
  public class StubSuccessAuthenticationService : IAuthenticationService
  {
    public User Login(string username, string password)
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