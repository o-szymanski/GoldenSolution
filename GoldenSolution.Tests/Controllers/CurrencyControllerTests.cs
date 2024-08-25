using GoldenSolution.Api.Controllers.Currency;
using GoldenSolution.Core.Functions.Queries.Currency;
using GoldenSolution.Core.Models.DTO.Currency;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GoldenSolution.Tests.Controllers;

[TestFixture]
public class CurrencyControllerTests
{
    private Mock<IMediator> _mediatorMock;
    private CurrencyController _currencyController;

    [SetUp]
    public void Setup()
    {
        _mediatorMock = new Mock<IMediator>();
        _currencyController = new CurrencyController(_mediatorMock.Object);
    }

    [Test]
    public async Task GetCurrencyExchangeRatesAsync_ShouldReturnOkResult_WhenCurrencyExchangeRatesExist()
    {
        // Arrange
        var currencyExchangeRates = new List<CurrencyExchangeDto>
        {
            new("A", "001", "2023-08-25",
            [
                new("US Dollar", "USD", 3.75M),
                new("Euro", "EUR", 4.50M)
            ]),
            new("B", "002", "2023-08-26",
            [
                new("British Pound", "GBP", 5.00M),
                new("Swiss Franc", "CHF", 4.90M)
            ])
        };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCurrencyExchangeRatesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(currencyExchangeRates);

        // Act
        var result = await _currencyController.GetCurrencyExchangeRatesAsync();

        // Assert
        Assert.That(result, Is.InstanceOf<OkObjectResult>());
        var okResult = result as OkObjectResult;
        Assert.That(okResult, Is.Not.Null);
        Assert.That(okResult!.Value, Is.Not.Null);
        var returnValue = okResult.Value as List<CurrencyExchangeDto>;
        Assert.That(returnValue, Is.Not.Null);
        Assert.That(returnValue!, Has.Count.EqualTo(2));

        // Additional assertions to verify content  
        Assert.Multiple(() =>
        {
            Assert.That(returnValue![0].Table, Is.EqualTo("A"));
            Assert.That(returnValue[0].Rates, Has.Count.EqualTo(2));
            Assert.That(returnValue[0].Rates[0].Currency, Is.EqualTo("US Dollar"));
            Assert.That(returnValue[0].Rates[0].Mid, Is.EqualTo(3.75M));
        });
    }

    [Test]
    public async Task GetCurrencyExchangeRatesAsync_ShouldReturnNotFound_WhenNoCurrencyExchangeRatesExist()
    {
        // Arrange
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetCurrencyExchangeRatesQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync((List<CurrencyExchangeDto>?)null);

        // Act
        var result = await _currencyController.GetCurrencyExchangeRatesAsync();

        // Assert
        Assert.That(result, Is.InstanceOf<NotFoundResult>());
    }
}
