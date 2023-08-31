using DNAKitStore.Models;

namespace DNAKitStore.Validation;

public interface IOrderValidation
{
    public bool IsKitQuantityValid(int kitQuantity);
    public bool IsDeliveryDateValid(DateTime deliveryDate);
    public bool IsCustomerIdValid(int customerId);
}