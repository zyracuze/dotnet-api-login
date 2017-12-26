using System;
using api.Services;
using api.Models;
using api.Exceptions;

namespace api.UnitTest
{
  public class StubUserContextThrowException : IUserContext
  {
    public User FindUserByUsernameAndPassword(string username, string hashPassword)
    {
      throw new UserNotFoundException("User not found");
    }
  }
}