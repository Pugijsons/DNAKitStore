using DNAKitStore.Validation;
using FluentAssertions;

namespace DNAKitStore.tests;

public class OrderValidationTests
{

    private IOrderValidation _orderValidation;

    [SetUp]
    public void Setup()
    {
        _orderValidation = new OrderValidation();
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

}