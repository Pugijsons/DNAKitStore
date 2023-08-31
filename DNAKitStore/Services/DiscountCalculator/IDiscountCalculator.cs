namespace DNAKitStore.Services.DiscountCalculator;

public interface IDiscountCalculator
{
    public decimal CalculateDiscount(decimal finalPrice, int kitQuantity);
}