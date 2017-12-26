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

       
        public void Username_Must_Be_Required()
        {
            // Arrange
            var model = new User
            {
                Username = ""
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.False(valid);
            var failure = Assert.Single(
                result,
                x => x.ErrorMessage == "The Username field is required.");
            Assert.Single(failure.MemberNames, x => x == "Username");
        }

       
        public void Username_Should_Not_Over_50_Characters()
        {
            // Arrange
            var model = new User
            {
                Username = new string('a', 49)
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

      
        public void Username_Should_Over_4_Characters()
        {
            // Arrange
            var model = new User
            {
                Username = "pl0oy"
            };

            var context = new ValidationContext(model, null, null);
            var result = new List<ValidationResult>();

            // Act
            var valid = Validator.TryValidateObject(model, context, result, true);

            Assert.False(valid);
            var failure = Assert.Single(
                result,
                x => x.ErrorMessage == "The field Username must be a string with a minimum length of 4.");
            Assert.Single(failure.MemberNames, x => x == "Username");
        }
    }
}