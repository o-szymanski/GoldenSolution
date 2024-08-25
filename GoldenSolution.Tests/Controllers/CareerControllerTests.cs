using GoldenSolution.Api.Controllers.Career;
using GoldenSolution.Core.Functions.Queries.Career;
using GoldenSolution.Core.Models.DTO.Career;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace GoldenSolution.Tests.Controllers;

[TestFixture]
public class CareerControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private CareerController _careerController;

    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _careerController = new CareerController(_mediatorMock.Object);
    }

    [Test]
    public async Task GetCareersAsync_ShouldReturnOkResult_WhenCareersExist()
    {
        // Arrange
        var careers = new List<CareerDto>
        {
            new(1, "Software Developer", "Develops software", "Remote", "C#, .NET", 60000, "email@example.com"),
            new(2, "Project Manager", "Manages projects", "On-site", "Management, Agile", 75000, "contact@company.com")
        };
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCareerQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(careers);

        // Act
        var result = await _careerController.GetCareersAsync();

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.Not.Null);
        var returnValue = okResult.Value as List<CareerDto>;
        Assert.That(returnValue, Is.Not.Null);
        Assert.That(returnValue!, Has.Count.EqualTo(2));
    }

    [Test]
    public async Task GetCareersAsync_ShouldReturnNotFound_WhenNoCareersExist()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllCareerQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((List<CareerDto>?)null);

        // Act
        var result = await _careerController.GetCareersAsync();

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }
}
