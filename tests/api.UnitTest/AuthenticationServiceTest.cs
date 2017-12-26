using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using api.Controllers;
using api.Models;
using api.Services;
using api.Exceptions;

namespace api.UnitTest
{

  public class AuthenticationServiceTest
  {
    [Fact]
    public void Login_ReturnUserModel_WhenUserLoginSuccess()
    {
      var username = "ploy";
      var hashPassword = "2ebaee7d310c99cb38e069a7014d64bd4b043caa1646489bdc4b5f07f3479585";

      var expectedUser = new User(){
          Id = 1,
          Username = "ploy",
          Displayname = "พลอย"
      };

      StubUserContextSuccess stubUserContextSuccess = new StubUserContextSuccess();
      AuthenticationService authenticationService = new AuthenticationService(stubUserContextSuccess);

      User actualUser = authenticationService.Login(username, hashPassword);

      // Assert
      Assert.IsType<User>(actualUser);
      Assert.Equal(expectedUser.Id, actualUser.Id);
      Assert.Equal(expectedUser.Username, actualUser.Username);
      Assert.Equal(expectedUser.Displayname, actualUser.Displayname);

    }

    [Fact]
    public void Login_ThrowExceptionUserNotFound_WhenUserLoginFail()
    {
      var username = "ploy";
      var hashPassword = "Sck1234";

      var expectedUser = new User(){
          Id = 1,
          Username = "ploy",
          Displayname = "พลอย"
      };

      StubUserContextThrowException stubUserContextThrowException = new StubUserContextThrowException();
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

  }
}
