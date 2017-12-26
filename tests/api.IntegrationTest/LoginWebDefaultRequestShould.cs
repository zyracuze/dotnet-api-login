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

namespace api.IntegrationTest
{
  public class LoginWebDefaultRequestShould
  {
    private readonly TestServer server;
    private readonly HttpClient client;

    public LoginWebDefaultRequestShould()
    {
      // Arrange
      server = new TestServer(
        new WebHostBuilder().UseEnvironment("Development").UseStartup<Startup>());
        // .UseStartup<Startup>()
        // .ConfigureServices( 
        //   services => services.AddDbContext<UserContext>(
        //     options => options.UseSqlite("Data Source=../../src/api/Databases/account.db")
        //     ) 
        //   )
        // );
      client = server.CreateClient();
    }

    [Fact]
    public async void ReturnUserInfoGivenLoginInfo()
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
    public async void ReturnErrorRequireFieldGivenLoginInfoNotComplete(string username, string password)
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
  }
} 
