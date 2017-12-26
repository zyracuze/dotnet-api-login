using System;
using System.Security.Cryptography;
using System.Text;
using api.Models;

namespace api.Services
{
  public class AuthenticationService : IAuthenticationService
  {
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


      return new User()
      {
        Id = 1,
        Username = "ploy",
        Displayname = "พลอย"
      };
    }
  }
}