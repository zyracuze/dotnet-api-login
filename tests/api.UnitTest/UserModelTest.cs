using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Xunit;

namespace api.UnitTest
{
    public class UserTest
    {
        [Fact]
        public void Username_Must_Be_Under_50()
        {
            // Arrange
            var model = new User
            {
                Username = new string("ploy", 50)
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.False(valid);
            var failure = Assert.Single(
                result,
                x => x.ErrorMessage == "The field Username must be a string with a maximum length of 50.");
            Assert.Single(failure.MemberNames, x => x == "Username");
        }
    }
}