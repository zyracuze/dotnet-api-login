using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using api.Controllers;
using api.Models;

namespace api.UnitTest
{
  public class LoginControllerTest
  {
    [Fact]
    public void PostLogin_ResturnJSON_WhenLoginIsSuccessful()
    {

      var loginController = new LoginController();
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

      var loginController = new LoginController();
      var result = loginController.Post(new User()
      {
        Username = username,
        Password = password
      });

      var reponse = Assert.IsType<ResponseMessage>(result);

      Assert.Equal("ERROR", reponse.Status);
      Assert.Equal("Username and Password are required.", reponse.Message);
    }

    
  }
}
