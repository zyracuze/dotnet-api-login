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
        public void PostLogin_ResturnJSON_WhenLoginIsSuccessful(){

            var loginController = new LoginController();
            var result = loginController.Post( new User(){
                Username = "ploy",
                Password = "Sck1234"
            });

            var reponse = Assert.IsType<ResponseMessage>(result);
            var model = Assert.IsAssignableFrom<User>(reponse.Results);

            Assert.Equal("ploy", model.Username);
            Assert.Equal("พลอย", model.Displayname);
            Assert.Equal("OK", reponse.Status);
        }
    }
}
