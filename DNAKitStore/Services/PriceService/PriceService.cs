using DNAKitStore.Models;
using DNAKitStore.Services.DiscountService;

namespace DNAKitStore.Services.PriceService;

public class PriceService : IPriceService
{
    private readonly IDiscountService _discountService;

    public PriceService(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public Order ApplyFinalPriceToOrder(Order order)
    {
        order.FinalOrderPrice = order.KitQuantity * order.KitType.Price * _discountService.DiscountAmountFinder(order.KitQuantity);
        return order;
    }
}