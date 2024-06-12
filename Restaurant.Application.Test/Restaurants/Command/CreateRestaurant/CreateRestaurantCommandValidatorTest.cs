using FluentAssertions;
using FluentValidation.TestHelper;
using Restaurants.Clean.Application;

namespace Restaurant.Application.Test;

public class CreateRestaurantCommandValidatorTest
{
    [Fact]
    public void Validator_ForValidCommand_ShouldNotHaveValidationErrors()
    {
        // arrange

        var command = new CreateRestaurantCommand()
        {
            Name = "Test",
            Discription = "Test",
            ContactEmail = "test@test.com",
            Category = "Italian"
        };
    
        // act
        var validator = new CreateRestaurantCommandValidator();
        var result = validator.TestValidate(command);

        // assert
        result.IsValid.Should().BeTrue();
    }
    [Fact]
    public void Validator_ForInvalidCommand_ShouldHaveValidationErrors()
    {
        // arrange
        var command = new CreateRestaurantCommand()
        {
            Name = "Test",
            Discription = "Test",
            ContactEmail = "test@test",
            Category = "SriLankan"
        };
        // act
        var validator = new CreateRestaurantCommandValidator();
        var result = validator.TestValidate(command);

        //assert
       
        result.IsValid.Should().BeFalse();
        
    }
    [Theory]
    [InlineData("Chinese")]
    [InlineData("Italian")]
    public void Validator_ForValidCategory_ShouldNotHaveValidationErrors(string category)
    {
        // arrange
        var command = new CreateRestaurantCommand()
        {
            Category = category
        };
        // act
        var validator = new CreateRestaurantCommandValidator();
        var result = validator.TestValidate(command);
        // assert

        result.ShouldNotHaveValidationErrorFor(q=> q.Category);

    }
}