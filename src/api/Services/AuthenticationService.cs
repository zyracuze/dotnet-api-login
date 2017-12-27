using System;
using System.Security.Cryptography;
using System.Text;
using api.Models;
using api.Exceptions;
using api.Contexts;

namespace api.Services
{
  public class AuthenticationService
  {

    private readonly IUserContext userContext;
    public AuthenticationService(IUserContext userContext){
        this.userContext = userContext;
    }
    private string EncryptPassword(string password)
    {
      StringBuilder sb = new StringBuilder();

      using (var hash = SHA256.Create())
      {
        Byte[] result = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        foreach (Byte b in result)
          sb.Append(b.ToString("x2"));
      }
      return sb.ToString();
    }

    public User Login(string username, string password)
    {

      if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
      {
        throw new ArgumentException();
      }

      string hashPassword = this.EncryptPassword(password);

      try
      {
          return userContext.FindUserByUsernameAndPassword(username, hashPassword);
      }
      catch (UserNotFoundException)
      {   
          throw new UserNotFoundException("User not found");
      }
    }
  }
}