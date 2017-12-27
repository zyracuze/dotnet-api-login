using System;
using Xunit;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Exceptions;
using api.Contexts;

namespace api.IntegrationTest.Contexts
{
  public class UserContextTest
  {
    [Fact]
    public void FindUserByUsernameAndPassword_CorrectUser_ReturnsExpectedUser()
    {
      // Arrange
      var options = new DbContextOptionsBuilder<UserContext>()
          .UseInMemoryDatabase(databaseName: "account")
          .Options;
      using (var context = new UserContext(options))
      {
        context.Users.Add(
            new User
            {
              Username = "ploy",
              Password = "Sck1234",
              Displayname = "พลอย"
            }
        );
        context.SaveChanges();

        User expectedUser = new User()
        {
          Id = 1,
          Username = "ploy",
          Displayname = "พลอย"
        };

        // Act
        User actualUser = context.FindUserByUsernameAndPassword("ploy", "Sck1234");

        // Assert
        Assert.Equal(expectedUser.Id, actualUser.Id);
        Assert.Equal(expectedUser.Username, actualUser.Username);
        Assert.Equal(expectedUser.Displayname, actualUser.Displayname);
      }
    }

    [Fact]
    public void FindUserByUsernameAndPassword_NotExistUser_ThrowUserNotFoundException()
    {
      // Arrange
      var options = new DbContextOptionsBuilder<UserContext>()
          .UseInMemoryDatabase(databaseName: "account")
          .Options;
      using (var context = new UserContext(options))
      {
        context.Users.Add(
            new User
            {
              Username = "ploy",
              Password = "Sck1234",
              Displayname = "พลอย"
            }
        );
        context.SaveChanges();

        try
        {
          // Act
          context.FindUserByUsernameAndPassword("ploy", "1234");

          // Assert
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
}
