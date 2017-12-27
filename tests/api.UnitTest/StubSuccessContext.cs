using System;
using api.Services;
using api.Models;

namespace api.UnitTest
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