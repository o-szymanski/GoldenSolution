using GoldenSolution.Api.Controllers.Status;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Tests.Controllers;

public class StatusControllerTest
{
	private StatusController _statusController;

	[SetUp]
	public void Setup()
	{
		_statusController = new StatusController();
	}

	[Test]
	public void GetStatus_ReturnsOkResult()
	{
		// Act
		var result = _statusController.GetStatus();

		// Assert
		Assert.That(result, Is.InstanceOf<OkObjectResult>());
	}
}
