using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using api.Controllers;
using api.Models;
using api.Services;
using api.Exceptions;

namespace api.UnitTest
{
  public class LoginControllerTest
  {
    [Fact]
    public void PostLogin_ResturnJSON_WhenLoginIsSuccessful()
    {
      var service = new StubSuccessAuthenticationService();
      var loginController = new LoginController(service);
      var result = loginController.Post(new User()
      {
        Username = "ploy",
        Password = "Sck1234"
      });

      var reponse = Assert.IsType<ResponseMessage>(result);
      var model = Assert.IsAssignableFrom<User>(reponse.Results);

      Assert.Equal("ploy", model.Username);
      Assert.Equal("พลอย", model.Displayname);
      Assert.Equal("OK", reponse.Status);
    }

    [Theory]
    [InlineData("", "Sck1234")]
    [InlineData("ploy", "")]
    [InlineData("", "")]
    public void PostLogin_ResturnErrorRequireField_WhenLoginInfoHaveNullField(string username, string password)
    {
      var service = new StubSuccessAuthenticationService();
      var loginController = new LoginController(service);
      var result = loginController.Post(new User()
      {
        Username = username,
        Password = password
      });

      var reponse = Assert.IsType<ResponseMessage>(result);

      Assert.Equal("ERROR", reponse.Status);
      Assert.Equal("Username and Password are required.", reponse.Message);
    }

    [Theory]
    [InlineData("ploy", "1234")]
    [InlineData("nut", "Sck1234")]
    [InlineData("nut", "1234")]
    public void PostLogin_ResturnErrorUserNotFound_WhenLoginInfoIsInCorrect(string username, string password)
    {
      StubFailAuthenticationService service = new StubFailAuthenticationService();

      var loginController = new LoginController(service);
      var result = loginController.Post(new User()
      {
        Username = username,
        Password = password
      });

      var reponse = Assert.IsType<ResponseMessage>(result);

      Assert.Equal("ERROR", reponse.Status);
      Assert.Equal("User not found", reponse.Message);
    }

  }
}
