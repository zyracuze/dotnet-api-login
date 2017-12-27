using api.Exceptions;
using api.Models;
using api.Services;

namespace api.UnitTest.Services
{
    public class StubFailAuthenticationService : IAuthenticationService
    {
        public User Login(string username, string password)
        {
            throw new UserNotFoundException("User not found");
        }
    }
}