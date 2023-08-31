using DNAKitStore.Exceptions;
using DNAKitStore.Models;
using DNAKitStore.Storage;
using FluentAssertions;

namespace DNAKitStore.tests;

public class OrderStorageTests
{
    private IOrderStorage _orderStorage;
    private List<Order> _orderList;
    private RegularDnaKit _testKit;
    private Order _testOrder;

    [SetUp]
    public void Setup()
    {
        _orderList = new List<Order>();
        _orderStorage = new OrderStorage(_orderList);
        _testKit = new RegularDnaKit();
        _testOrder = new Order(1, DateTime.UtcNow, 1, _testKit);
    }

    [Test]
    public void AddNewOrderToStorageAddNewOrderStorage()
    {
        _orderStorage.AddNewOrderToStorage(_testOrder);

        _orderList.Count.Should().Be(1);
    }

    [Test]
    public void AddNewOrderToStorageAddNullOrderThrowsInvalidOrderException()
    {
        _testOrder = null;

        Action action = () => _orderStorage.AddNewOrderToStorage(_testOrder);

        action.Should().Throw<InvalidOrderException>();
    }

    [Test]
    public void FetchAllOrdersReturnsAllOrders()
    {
        _orderList.Add(_testOrder);

        _orderStorage.FetchAllOrders().Count.Should().Be(1);
    }

    [Test]
    public void FetchAllOrdersEmptyStorageReturnsEmptyList()
    {
        _orderStorage.FetchAllOrders().Count.Should().Be(0);
    }

    [Test]
    public void FetchAllCustomerOrdersReturnsCustomerOrder()
    {
        Order order = new Order(2, DateTime.UtcNow, 2, _testKit);

        _orderList.Add(_testOrder);
        _orderList.Add(order);

        _orderStorage.FetchAllCustomerOrders(1).Count.Should().Be(1);
    }

    [Test]
    public void FetchAllCustomerOrdersNonExistingOrderShouldReturnEmptyList()
    {
        _orderStorage.FetchAllCustomerOrders(99).Count.Should().Be(0);
    }
}