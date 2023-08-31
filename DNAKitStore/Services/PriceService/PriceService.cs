using DNAKitStore.Exceptions;
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
        if (order == null)
        {
            throw new InvalidOrderException();
        }

        order.FinalOrderPrice = decimal.Round(order.KitQuantity * order.KitType.Price * _discountService.DiscountAmountFinder(order.KitQuantity), 2);
        return order;
    }
}