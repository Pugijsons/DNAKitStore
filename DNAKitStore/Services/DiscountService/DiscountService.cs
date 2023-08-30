using DNAKitStore.Models;

namespace DNAKitStore.Services.DiscountService;

public class DiscountService : IDiscountService
{
    public double DiscountCalculator(Order order)
    {
        if (order.KitQuantity >= 10 && order.KitQuantity < 50)
        {
            return 0.95;
        }

        if (order.KitQuantity >= 50)
        {
            return 0.85;
        }

        return 1;
    }
}