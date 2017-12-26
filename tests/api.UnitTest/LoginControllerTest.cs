using System;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using api.Controllers;
using api.Models;
using api.Services;

namespace api.UnitTest
{
  public class LoginControllerTest
  {
    [Fact]
    public void PostLogin_ResturnJSON_WhenLoginIsSuccessful()
    {

      var mockRepo = new Mock<IAuthenticationService>();
      mockRepo.Setup(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(
            new User()
            {
              Id = 1,
              Username = "ploy",
              Displayname = "พลอย"
            }
        );

      var loginController = new LoginController(mockRepo.Object);
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
      var mockRepo = new Mock<IAuthenticationService>();
      mockRepo.Setup(repo => repo.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(
            new User()
            {
              Id = 1,
              Username = "ploy",
              Displayname = "พลอย"
            }
        );

      var loginController = new LoginController(mockRepo.Object);
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
