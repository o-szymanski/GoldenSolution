using GoldenSolution.Api.Controllers.User;
using GoldenSolution.Core.Functions.Commands.User;
using GoldenSolution.Core.Functions.Queries.User;
using GoldenSolution.Core.Models.DTO.User;
using GoldenSolution.Core.Models.Requests.User;
using GoldenSolution.Core.Models.Responses.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GoldenSolution.Tests.Controllers;

[TestFixture]
public class UserControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private UserController _userController;

    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _userController = new UserController(_mediatorMock.Object);
    }

    [Test]
    public async Task GetUserDataById_ShouldReturnOk_WhenUserExists()
    {
        // Arrange
        var userId = "123";
        var userDto = new UserDto(userId, "testuser", null, "test@example.com", "TEST@EXAMPLE.COM", true, null, null, null, "1234567890", true, false, null, true, 0);

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserDataByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(userDto);

        // Act
        var result = await _userController.GetUserDataById(userId);

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.EqualTo(userDto));
    }

    [Test]
    public async Task GetUserDataById_ShouldReturnNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = "123";
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetUserDataByIdQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((UserDto?)null);

        // Act
        var result = await _userController.GetUserDataById(userId);

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }

    [Test]
    public async Task Register_ShouldReturnOk_WhenRegistrationSucceeds()
    {
        // Arrange
        var registerRequest = new RegisterUserRequest("test@example.com", "Password123!");
        var identityResult = IdentityResult.Success;

        _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(identityResult);

        // Act
        var result = await _userController.Register(registerRequest);

        // Assert
        Assert.That(result, Is.InstanceOf<OkResult>());
    }

    [Test]
    public async Task Register_ShouldReturnBadRequest_WhenRegistrationFails()
    {
        // Arrange
        var registerRequest = new RegisterUserRequest("test@example.com", "Password123!");
        var identityResult = IdentityResult.Failed(new IdentityError { Description = "Email is already taken" });

        _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(identityResult);

        // Act
        var result = await _userController.Register(registerRequest);

        // Assert
        Assert.That(result, Is.InstanceOf<BadRequestObjectResult>());
        var badRequestResult = result as BadRequestObjectResult;
        Assert.That(badRequestResult!.Value, Is.EqualTo("Email is already taken"));
    }

    [Test]
    public async Task Login_ShouldReturnOk_WhenLoginSucceeds()
    {
        // Arrange
        var loginRequest = new LoginUserRequest("test@example.com", "Password123!");
        var loginResponse = new LoginUserResponse
        {
            AccessToken = "fake_token",
            TokenType = "Bearer",
            ExpiresIn = 3600,
            RefreshToken = "fake_refresh_token"
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<LoginUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync(loginResponse);

        // Act
        var result = await _userController.Login(loginRequest);

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.EqualTo(loginResponse));
    }

    [Test]
    public async Task Login_ShouldReturnUnauthorized_WhenLoginFails()
    {
        // Arrange
        var loginRequest = new LoginUserRequest("test@example.com", "WrongPassword!");

        _mediatorMock.Setup(m => m.Send(It.IsAny<LoginUserCommand>(), It.IsAny<CancellationToken>())).ReturnsAsync((LoginUserResponse?)null);

        // Act
        var result = await _userController.Login(loginRequest);

        // Assert
        Assert.That(result, Is.InstanceOf<UnauthorizedObjectResult>());
        var unauthorizedResult = result as UnauthorizedObjectResult;
        Assert.That(unauthorizedResult!.Value, Is.EqualTo("Invalid email or password"));
    }
}
