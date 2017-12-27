using System;
using Xunit;
using api.Models;
using api.Services;
using api.Exceptions;
using api.UnitTest.Contexts;

namespace api.UnitTest.Services
{

  public class AuthenticationServiceTest
  {
    [Fact]
    public void Login_CorrectUser_ReturnsExpectedUser()
    {
      var username = "ploy";
      var hashPassword = "2ebaee7d310c99cb38e069a7014d64bd4b043caa1646489bdc4b5f07f3479585";

      var expectedUser = new User(){
          Id = 1,
          Username = "ploy",
          Displayname = "พลอย"
      };

      StubSuccessUserContext stubSuccessUserContext = new StubSuccessUserContext();
      AuthenticationService authenticationService = new AuthenticationService(stubSuccessUserContext);

      User actualUser = authenticationService.Login(username, hashPassword);

      // Assert
      Assert.IsType<User>(actualUser);
      Assert.Equal(expectedUser.Id, actualUser.Id);
      Assert.Equal(expectedUser.Username, actualUser.Username);
      Assert.Equal(expectedUser.Displayname, actualUser.Displayname);

    }

    [Fact]
    public void Login_NotExistUser_ThrowExceptionUserNotFound()
    {
      var username = "ploy";
      var hashPassword = "Sck1234";

      var expectedUser = new User(){
          Id = 1,
          Username = "ploy",
          Displayname = "พลอย"
      };

      StubThrowExceptionUserContext stubUserContextThrowException = new StubThrowExceptionUserContext();
      AuthenticationService authenticationService = new AuthenticationService(stubUserContextThrowException);

      try
      {

        User actualUser = authenticationService.Login(username, hashPassword);
        Assert.True(false, "UserNotFoundException was not thrown");

      }
      catch (UserNotFoundException)
      {
        // Assert
        Assert.True(true);
      }

    }

    [Theory]
    [InlineData("","Sck1234")]
    [InlineData("ploy","")]
    public void Login_NotExistUser_ThrowArgumentException(string username, string hashPassword)
    {
      StubSuccessUserContext stubSuccessUserContext = new StubSuccessUserContext();
      AuthenticationService authenticationService = new AuthenticationService(stubSuccessUserContext);

      try
      {
        User actualUser = authenticationService.Login(username, hashPassword);
        Assert.True(false, "ArgumentException was not thrown");
      }
      catch (ArgumentException)
      {
        // Assert
        Assert.True(true);
      }
    }
    
  }
}
