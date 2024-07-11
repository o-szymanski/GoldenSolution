using GoldenSolution.Api.Controllers.Status;
using Microsoft.AspNetCore.Mvc;

namespace GoldenSolution.Tests;

public class Tests
{
	private StatusController _controller;

	[SetUp]
	public void Setup()
	{
		_controller = new StatusController();
	}

	[Test]
	public void GetStatus_ReturnsOkResult()
	{
		// Act
		var result = _controller.GetStatus();

		// Assert
		Assert.That(result, Is.InstanceOf<OkResult>());
	}
}
