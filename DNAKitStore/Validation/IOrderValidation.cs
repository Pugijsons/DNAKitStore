using DNAKitStore.Models;

namespace DNAKitStore.Validation;

public interface IOrderValidation
{
    public bool IsOrderValid(Order order);
}