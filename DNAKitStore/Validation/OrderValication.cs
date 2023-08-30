using DNAKitStore.Models;

namespace DNAKitStore.Validation;

public class OrderValidation : IOrderValidation
{
    public bool IsOrderValid(Order order)
    {
        if (order.ExpectedDelivery <= DateTime.UtcNow)
        {
            return false;
        }

        if (order.KitQuantity <= 0 || order.KitQuantity % 1 != 0 || order.KitQuantity > 999)
        {
            return false;
        }

        if (order.CustomerId < 0)
        {
            return false;
        }

        return true;
    }
}