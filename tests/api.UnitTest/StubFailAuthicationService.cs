using System;
using api.Exceptions;
using api.Models;
using api.Services;

namespace api.UnitTest
{
    public class StubFailAuthenticationService : IAuthenticationService
    {
        public User Login(string username, string password)
        {
            throw new UserNotFoundException("User not found");
        }
    }
}