using api.Models;
using api.Exceptions;

namespace api.UnitTest.Contexts
{
  public class StubThrowExceptionUserContext : IUserContext
  {
    public User FindUserByUsernameAndPassword(string username, string hashPassword)
    {
      throw new UserNotFoundException("User not found");
    }
  }
}