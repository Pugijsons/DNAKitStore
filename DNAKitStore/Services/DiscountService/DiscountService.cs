namespace DNAKitStore.Services.DiscountService;

public class DiscountService : IDiscountService
{
    private const int SmallOrderTreshold = 10;
    private const int LargeOrderTreshold = 50;
    private const decimal SmallDiscountConstant = 0.95m;
    private const decimal LargeDiscountConstant = 0.85m;
    private const decimal NoDiscount = 1m;

    public decimal DiscountAmountFinder(int orderKitQuantity)
    {
        if (orderKitQuantity is >= SmallOrderTreshold and < LargeOrderTreshold)
        {
            return SmallDiscountConstant;
        }

        if (orderKitQuantity >= LargeOrderTreshold)
        {
            return LargeDiscountConstant;
        }

        return NoDiscount;
    }
}