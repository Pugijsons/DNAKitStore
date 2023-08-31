using DNAKitStore.Exceptions;
using DNAKitStore.Models;
using DNAKitStore.Services.OrderService;
using DNAKitStore.Services.PriceService;
using DNAKitStore.Storage;
using DNAKitStore.Validation;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace DNAKitStore.tests;

public class OrderServiceTests
{
    private OrderService _orderService;
    private AutoMocker _autoMocker;
    private RegularDnaKit _testKit;


    [SetUp]
    public void Setup()
    {
        _autoMocker = new AutoMocker();
        _orderService = _autoMocker.CreateInstance<OrderService>();
        _testKit = new RegularDnaKit();
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
    public void CreateNewOrderAppliesFinalPrice()
    {
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsCustomerIdValid(It.IsAny<int>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsDeliveryDateValid(It.IsAny<DateTime>())).Returns(true);
        _autoMocker.GetMock<IOrderValidation>().Setup(o => o.IsKitQuantityValid(It.IsAny<int>())).Returns(true);

        _orderService.CreateNewOrder(1, DateTime.UtcNow, 1, _testKit);
        _autoMocker.GetMock<IPriceService>().Verify(o => o.ApplyFinalPriceToOrder(It.IsAny<Order>()), Times.Once);
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
    public void ListAllCustomerOrdersReturnsOrderList()
    {
        _autoMocker.GetMock<IOrderStorage>().Setup(o => o.FetchAllCustomerOrders(It.IsAny<int>())).Returns(new List<Order>());

        var customerList = _orderService.ListAllCustomerOrders(1);

        customerList.Should().BeOfType<List<Order>>();
    }
}