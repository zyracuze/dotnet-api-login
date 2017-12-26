using System;
using api.Models;

namespace api.Services
{
    public interface IAuthenticationSrevice
    {
         User Login(string username, string password);
         String EncryptPassword(string password);
    }
}