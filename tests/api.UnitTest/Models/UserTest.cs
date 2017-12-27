using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.Models;
using Xunit;

namespace api.UnitTest.Models
{
  public class UserTest
  {

    #region "Username"
    [Fact]
    public void Username_Should_Not_Empty()
    {
      // Arrange
      var model = new User
      {
        Username = string.Empty
      };
      string expectedMessage = "The Username field is required.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Username_3Charactor_Should_Error()
    {
      // Arrange
      var model = new User
      {
        Username = "abc"
      };
      string expectedMessage = "The field Username must be a string or array type with a minimum length of '4'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Username_4Charactor_Should_NoError()
    {
      // Arrange
      var model = new User
      {
        Username = "abcd"
      };
      string expectedMessage = "The field Username must be a string or array type with a minimum length of '4'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.False(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Username_50Charactor_Should_NoError()
    {
      // Arrange
      var model = new User
      {
        Username = "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeee"
      };
      string expectedMessage = "The field Username must be a string or array type with a maximum length of '50'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.False(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Username_51Charactor_Should_Error()
    {
      // Arrange
      var model = new User
      {
        Username = "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeef"
      };
      string expectedMessage = "The field Username must be a string or array type with a maximum length of '50'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }
    #endregion

    #region "Password"
    [Fact]
    public void Password_Should_Not_Empty()
    {
      // Arrange
      var model = new User
      {
        Password = string.Empty
      };
      string expectedMessage = "The Password field is required.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Password_7Charactor_Should_Error()
    {
      // Arrange
      var model = new User
      {
        Password = "abcdefg"
      };
      string expectedMessage = "The field Password must be a string or array type with a minimum length of '8'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Password_8Charactor_Should_NoError()
    {
      // Arrange
      var model = new User
      {
        Password = "abcdefgh"
      };
      string expectedMessage = "The field Password must be a string or array type with a minimum length of '8'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.False(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Password_50Charactor_Should_NoError()
    {
      // Arrange
      var model = new User
      {
        Password = "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeee"
      };
      string expectedMessage = "The field Password must be a string or array type with a maximum length of '50'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.False(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Password_51Charactor_Should_Error()
    {
      // Arrange
      var model = new User
      {
        Password = "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeef"
      };
      string expectedMessage = "The field Password must be a string or array type with a maximum length of '50'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }
    #endregion

    #region "Displayname"
    [Fact]
    public void Displayname_Should_Not_Empty()
    {
      // Arrange
      var model = new User
      {
        Displayname = string.Empty
      };
      string expectedMessage = "The Displayname field is required.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Displayname_3Charactor_Should_Error()
    {
      // Arrange
      var model = new User
      {
        Displayname = "abc"
      };
      string expectedMessage = "The field Displayname must be a string or array type with a minimum length of '4'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Displayname_4Charactor_Should_NoError()
    {
      // Arrange
      var model = new User
      {
        Displayname = "abcd"
      };
      string expectedMessage = "The field Displayname must be a string or array type with a minimum length of '4'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.False(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Displayname_100Charactor_Should_NoError()
    {
      // Arrange
      var model = new User
      {
        Displayname = "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeeaaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeee"
      };
      string expectedMessage = "The field Displayname must be a string or array type with a maximum length of '100'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.False(CheckValidateValue(results, expectedMessage));
      }
    }

    [Fact]
    public void Displayname_101Charactor_Should_Error()
    {
      // Arrange
      var model = new User
      {
        Displayname = "aaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeeaaaaaaaaaabbbbbbbbbbccccccccccddddddddddeeeeeeeeeex"
      };
      string expectedMessage = "The field Displayname must be a string or array type with a maximum length of '100'.";

      // Act
      var results = Validate(model);

      // Assert
      if (results.Count > 0)
      {
        Assert.True(CheckValidateValue(results, expectedMessage));
      }
    }
    #endregion

    #region "Utility"
    private static IList<ValidationResult> Validate(object model)
    {
      var results = new List<ValidationResult>();
      var validationContext = new ValidationContext(model, null, null);
      Validator.TryValidateObject(model, validationContext, results, true);
      if (model is IValidatableObject) (model as IValidatableObject).Validate(validationContext);
      return results;
    }
    private static bool CheckValidateValue(IList<ValidationResult> results, string expectedMessage)
    {
      foreach (ValidationResult message in results)
      {
        if (message.ErrorMessage == expectedMessage)
        {
          return true;
        }
      }
      return false;
    }
    #endregion
  }
}