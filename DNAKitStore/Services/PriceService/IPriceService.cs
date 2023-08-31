using DNAKitStore.Models;

namespace DNAKitStore.Services.PriceService;

public interface IPriceService
{
    public Order ApplyFinalPriceToOrder(Order order);
}