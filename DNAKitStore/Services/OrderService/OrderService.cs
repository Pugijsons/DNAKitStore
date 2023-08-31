using DNAKitStore.Models;
using DNAKitStore.Storage;
using DNAKitStore.Validation;
using DNAKitStore.Exceptions;
using DNAKitStore.Services.PriceService;

namespace DNAKitStore.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly IOrderStorage _orderStorage;
    private readonly IOrderValidation _orderValidation;
    private readonly IPriceService _priceService;

    public OrderService(IOrderStorage orderStorage, IOrderValidation orderValidation, IPriceService priceService)
    {
        _orderStorage = orderStorage;
        _orderValidation = orderValidation;
        _priceService = priceService;
    }

    public void CreateNewOrder(int customerId, DateTime expectedDelivery, int kitQuantity, IBaseDnaKit kitType)
    {
        if (_orderValidation.IsCustomerIdValid(customerId) == false)
        {
            throw new InvalidCustomerIdException();
        }

        if (_orderValidation.IsDeliveryDateValid(expectedDelivery) == false)
        {
            throw new InvalidDeliveryDateException();
        }

        if (_orderValidation.IsKitQuantityValid(kitQuantity) == false)
        {
            throw new InvalidQuantityException();
        }

        Order order = new Order(customerId, expectedDelivery, kitQuantity, kitType);
        order = _priceService.ApplyFinalPriceToOrder(order);
        _orderStorage.AddNewOrderToStorage(order);
    }

    public List<Order> ListAllCustomerOrders(int customerId)
    {
        return _orderStorage.FetchAllCustomerOrders(customerId);
    }
}