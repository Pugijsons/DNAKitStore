using DNAKitStore.Models;

namespace DNAKitStore.Services.DiscountService;

public interface IDiscountService
{
    public double DiscountCalculator(Order order);
}