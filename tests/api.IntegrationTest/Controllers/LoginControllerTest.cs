using System;
using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;

using System.Text;
using Newtonsoft.Json;
using api.Models;
using System.Threading.Tasks;

namespace api.IntegrationTest.Controllers
{
  public class LoginControllerTest
  {
    private readonly TestServer server;
    private readonly HttpClient client;

    public LoginControllerTest()
    {
      // Arrange
      server = new TestServer(
        new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
      client = server.CreateClient();
    }

    [Fact]
    public async Task Post_CorrectUser_ReturnsOKResponse()
    {
      var request = "/api/login";
      String jsonData = "{ \"username\": \"ploy\", \"password\": \"Sck1234\"}";
      HttpContent payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var response = await client.PostAsync(request, payload);
      response.EnsureSuccessStatusCode();

      ResponseMessage results = JsonConvert.DeserializeObject<ResponseMessage>(await response.Content.ReadAsStringAsync());

      Assert.Equal("OK", results.Status);
      Assert.Equal("ploy", results.Results.Username);
      Assert.Equal("พลอย", results.Results.Displayname);
    }

    [Theory]
    [InlineData("","Sck1234")]
    [InlineData("ploy","")]
    [InlineData("","")]
    public async Task Post_NotExistUser_ReturnErrorRequireFieldResponse(string username, string password)
    {
      var request = "/api/login";
      String jsonData = "{ \"username\": \""+username+"\", \"password\": \""+password+"\"}";
      HttpContent payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var response = await client.PostAsync(request, payload);
      response.EnsureSuccessStatusCode();


      ResponseMessage results = JsonConvert.DeserializeObject<ResponseMessage>(await response.Content.ReadAsStringAsync());

      Assert.Equal("ERROR", results.Status);
      Assert.Equal("Username and Password are required.", results.Message);
    }

    [Theory]
    [InlineData("ploy","1234")]
    [InlineData("nut","Sck1234")]
    [InlineData("nut","1234")]
    public async Task Post_NotExistUser_ReturnErrorUserNotFoundResponse(string username, string password)
    {
      var request = "/api/login";
      String jsonData = "{ \"username\": \""+username+"\", \"password\": \""+password+"\"}";
      HttpContent payload = new StringContent(jsonData, Encoding.UTF8, "application/json");
      var response = await client.PostAsync(request, payload);
      response.EnsureSuccessStatusCode();

      ResponseMessage results = JsonConvert.DeserializeObject<ResponseMessage>(await response.Content.ReadAsStringAsync());

      Assert.Equal("ERROR", results.Status);
      Assert.Equal("User not found", results.Message);
    }
  }
} 
