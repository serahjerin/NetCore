using FluentValidation.TestHelper;
using Xunit;
using LearningApp.Core.DTOs;
using LearningApp.Core.Validators;
using System;

namespace LearningApp.Tests
{
    public class CreateProductValidatorTests
    {
        private readonly CreateProductValidator _validator;

        public CreateProductValidatorTests()
        {
            _validator = new CreateProductValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            // Arrange
            var model = new CreateProductDto { Name = "jerin" };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            Console.WriteLine("name is not null");
        }

        [Fact]
        public void Should_Have_Error_When_Name_Exceeds_MaxLength()
        {
            // Arrange
            var model = new CreateProductDto { Name = new string('a', 201) };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
            
        }

        [Fact]
        public void Should_Have_Error_When_Price_Is_Zero_Or_Negative()
        {
            // Arrange
            var model = new CreateProductDto { Price = 0 };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Price);
        }

        [Fact]
        public void Should_Have_Error_When_Stock_Is_Negative()
        {
            // Arrange
            var model = new CreateProductDto { Stock = -1 };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Stock);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Model_Is_Valid()
        {
            // Arrange
            var model = new CreateProductDto
            {
                Name = "Valid Product",
                Description = "Valid description",
                Price = 10.99m,
                Stock = 5,
                CategoryId = 1
            };

            // Act & Assert
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}