using DNAKitStore.Services.DiscountService;
using FluentAssertions;

namespace DNAKitStore.tests;

public class DiscountServiceTests
{
    private DiscountService _discountService;

    [SetUp]
    public void Setup()
    {
        _discountService = new DiscountService();
    }

    [Test]
    public void DiscountAmountFinderReturnsNoDiscountWithValuesUnderTen()
    {
        _discountService.DiscountAmountFinder(9).Should().Be(1m);
    }

    [Test]
    public void DiscountAmountFinderReturnsFivePercentDiscountWithValuesOverTenAndUnderFifty()
    {
        _discountService.DiscountAmountFinder(35).Should().Be(0.95m);
    }

    [Test]
    public void DiscountAmountFinderReturnsFifteenPercentDiscountWithValuesOverFifty()
    {
        _discountService.DiscountAmountFinder(51).Should().Be(0.85m);
    }
}