using System;
using api.Models;

namespace api.Services
{
    public interface IAuthenticationService
    {
         User Login(string username, string password);
    }
}