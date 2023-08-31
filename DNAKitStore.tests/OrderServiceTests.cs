using DNAKitStore.Exceptions;
using DNAKitStore.Models;
using DNAKitStore.Services.DiscountCalculator;
using DNAKitStore.Services.OrderService;
using DNAKitStore.Storage;
using DNAKitStore.Validation;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace DNAKitStore.tests;

public class OrderServiceTests
{
    private IOrderService _orderService;
    private AutoMocker _autoMocker;
    private RegularDnaKit _testKit;
    private Order _testOrder;


    [SetUp]
    public void Setup()
    {
        _autoMocker = new AutoMocker();
        _orderService = _autoMocker.CreateInstance<OrderService>();
        _testKit = new RegularDnaKit();
        _testOrder = new Order(1, DateTime.UtcNow, 1, _testKit);
    }

    [Test]
    public void CreateNewOrderCreateValidOrder()
    {
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsCustomerIdValid(It.IsAny<int>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsDeliveryDateValid(It.IsAny<DateTime>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsKitQuantityValid(It.IsAny<int>())).Returns(true);

        _orderService.CreateNewOrder(1, DateTime.UtcNow, 1, _testKit);
        _autoMocker.GetMock<IOrderStorage>().Verify(o => o.AddNewOrderToStorage(It.IsAny<Order>()), Times.Once);
    }

    [Test]
    public void CreateNewOrderInvalidCustomerIdThrowsInvalidCustomerIdException()
    {
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsCustomerIdValid(It.IsAny<int>())).Returns(false);

        Action action = () => _orderService.CreateNewOrder(1, DateTime.UtcNow, 1, _testKit);
        action.Should().Throw<InvalidCustomerIdException>();
    }

    [Test]
    public void CreateNewOrderInvalidDeliveryDateThrowsInvalidDeliveryDateException()
    {
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsCustomerIdValid(It.IsAny<int>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsDeliveryDateValid(It.IsAny<DateTime>())).Returns(false);

        Action action = () => _orderService.CreateNewOrder(1, DateTime.UtcNow, 1, _testKit);
        action.Should().Throw<InvalidDeliveryDateException>();
    }

    [Test]
    public void CreateNewOrderInvalidKitQuantityThrowsInvalidQuantityException()
    {
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsCustomerIdValid(It.IsAny<int>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsDeliveryDateValid(It.IsAny<DateTime>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsKitQuantityValid(It.IsAny<int>())).Returns(false);

        Action action = () => _orderService.CreateNewOrder(1, DateTime.UtcNow, 1, _testKit);
        action.Should().Throw<InvalidQuantityException>();
    }

    [Test]
    public void CalculateFinalPriceReturnsCorrectPrice()
    {
        _autoMocker.GetMock<IDiscountCalculator>().Setup(o => o.CalculateDiscount(It.IsAny<decimal>(), It.IsAny<int>())).Returns(1);

        _orderService.CalculateFinalPrice(_testOrder);

        _testOrder.FinalOrderPrice.Should().Be(1);
    }

    [Test]
    public void ListAllCustomerOrdersReturnsOrderList()
    {
        _autoMocker.GetMock<IOrderStorage>().Setup(o => o.FetchAllCustomerOrders(It.IsAny<int>())).Returns(new List<Order>());

        var customerList = _orderService.ListAllCustomerOrders(1);

        customerList.Should().BeOfType<List<Order>>();
    }
}