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
    }
}