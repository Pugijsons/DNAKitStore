using DNAKitStore.Models;
using Microsoft.VisualBasic;

namespace DNAKitStore.Services.DiscountService;

public class DiscountService : IDiscountService
{
    public decimal DiscountAmountFinder(int orderKitQuantity)
    {
        if (orderKitQuantity is >= 10 and < 50)
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