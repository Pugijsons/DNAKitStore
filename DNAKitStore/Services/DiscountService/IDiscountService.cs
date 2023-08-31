using DNAKitStore.Models;

namespace DNAKitStore.Services.DiscountService;

public interface IDiscountService
{
    public decimal DiscountAmountFinder(int orderKitQuantity);
}