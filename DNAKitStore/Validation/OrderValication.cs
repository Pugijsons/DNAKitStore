﻿using DNAKitStore.Models;

namespace DNAKitStore.Validation;

public class OrderValidation : IOrderValidation
{
    public bool IsKitQuantityValid(int kitQuantity )
    {
        if (kitQuantity <= 0 || kitQuantity > 999)
        {
            return false;
        }

        return true;
    }

    public bool IsCustomerIdValid(int customerId)
    {
        if (customerId < 0)
        {
            return false;
        }

        return true;
    }

    public bool IsDeliveryDateValid(DateTime expectedDelivery)
    {
        if (expectedDelivery <= DateTime.UtcNow)
        {
            return false;
        }

        return true;
    }
}