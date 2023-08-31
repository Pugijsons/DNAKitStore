using DNAKitStore.Models;

namespace DNAKitStore.Services.DiscountService;

public class DiscountService : IDiscountService
{
    public decimal DiscountAmountFinder(int orderKitQuantity)
    {
        if (orderKitQuantity >= 10 && orderKitQuantity < 50)
        {
            return 0.95m;
        }

        if (orderKitQuantity >= 50)
        {
            return 0.85m;
        }

        return 1m;
    }
}