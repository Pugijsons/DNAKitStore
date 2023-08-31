using DNAKitStore.Exceptions;
using DNAKitStore.Models;
using DNAKitStore.Services.DiscountService;
using DNAKitStore.Services.PriceService;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace DNAKitStore.tests;

public class PriceServiceTests
{
    private PriceService _priceService;
    private AutoMocker _autoMocker;
    private Order _testOrder;
    private RegularDnaKit _testKit;

    [SetUp]
    public void Setup()
    {
        _autoMocker = new AutoMocker();
        _priceService = _autoMocker.CreateInstance<PriceService>();
        _testOrder = new Order(1, DateTime.UtcNow, 1, _testKit);
        _testKit = new RegularDnaKit();
    }

    [Test]
    public void ApplyFinalPriceToOrderReturnsOrderWithCorrectFinalPrice()
    {
        _autoMocker.GetMock<IDiscountService>().Setup(o => o.DiscountAmountFinder(It.IsAny<int>())).Returns(0.5m);
        var order = _priceService.ApplyFinalPriceToOrder(_testOrder);
        order.FinalOrderPrice.Should().Be(decimal.Round(98.99m * 0.5m, 2));
    }

    [Test]
    public void ApplyFinalPriceToOrderThrowsInvalidOrderExceptionWithNull()
    {
        Order order = null;
        Action action = () => _priceService.ApplyFinalPriceToOrder(order);

        action.Should().Throw<InvalidOrderException>();
    }
}