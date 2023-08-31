using DNAKitStore.Validation;
using FluentAssertions;

namespace DNAKitStore.tests;

public class OrderValidationTests
{

    private IOrderValidation _orderValidation;
    private DateTime _testDateTime;

    [SetUp]
    public void Setup()
    {
        _orderValidation = new OrderValidation();
        _testDateTime = DateTime.UtcNow;
    }

    [Test]
    public void IsKitQuantityValidReturnsTrueWithValidQuantity()
    {
        _orderValidation.IsKitQuantityValid(1).Should().BeTrue();
    }

    [Test]
    public void IsKitQuantityValidReturnsFalseWithZero()
    {
        _orderValidation.IsKitQuantityValid(0).Should().BeFalse();
    }

    [Test]
    public void IsKitQuantityValidReturnsFalseWithNegativeQuantity()
    {
        _orderValidation.IsKitQuantityValid(-1).Should().BeFalse();
    }

    [Test]
    public void IsKitQuantityValidReturnsFalseWithQuantityOverLimit()
    {
        _orderValidation.IsKitQuantityValid(1000).Should().BeFalse();
    }

    [Test]
    public void IsCustomerIdValidReturnsTrueWithValidCustomerId()
    {
        _orderValidation.IsCustomerIdValid(0).Should().BeTrue();
    }

    [Test]
    public void IsCustomerIdValidReturnsFalseWithNegativeCustomerId()
    {
        _orderValidation.IsCustomerIdValid(-1).Should().BeFalse();
    }

    [Test]
    public void IsDeliveryDateValidReturnsTrueWithValidDeliveryDate()
    {
        _orderValidation.IsDeliveryDateValid(_testDateTime.AddDays(1)).Should().BeTrue();
    }

    [Test]
    public void IsDeliveryDateValidReturnsFalseWithDeliveryDateNow()
    {
        _orderValidation.IsDeliveryDateValid(DateTime.UtcNow).Should().BeFalse();
    }

    [Test]
    public void IsDeliveryDateValidReturnsFalseWithDeliveryDateInPast()
    {
        _orderValidation.IsDeliveryDateValid(_testDateTime.AddDays(-1)).Should().BeFalse();
    }
}