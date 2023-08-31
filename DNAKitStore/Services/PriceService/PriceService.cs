using DNAKitStore.Models;
using DNAKitStore.Services.DiscountCalculator;
using DNAKitStore.Services.DiscountService;

namespace DNAKitStore.Services.PriceService;

public class PriceService : IPriceService
{
    private readonly IDiscountCalculator _discountCalculator;

    public PriceService(IDiscountCalculator discountCalculator)
    {
        _discountCalculator = discountCalculator;
    }

    public Order ApplyFinalPriceToOrder(Order order)
    {

    }
}