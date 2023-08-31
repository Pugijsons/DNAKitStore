using DNAKitStore.Services.DiscountService;

namespace DNAKitStore.Services.DiscountCalculator;

public class DiscountCalculator : IDiscountCalculator
{
    private readonly IDiscountService _discountService;

    public DiscountCalculator(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public decimal CalculateDiscount(decimal finalPrice, int kitQuantity)
    {
        var discountAmount = _discountService.DiscountAmountFinder(kitQuantity);
        return finalPrice * discountAmount;
    }
}