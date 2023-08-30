using DNAKitStore.Models;
using DNAKitStore.Services.DiscountService;
using DNAKitStore.Storage;
using DNAKitStore.Validation;
using DNAKitStore.Exceptions;

namespace DNAKitStore.Services.OrderService;

public class OrderService
{
    private readonly IOrderStorage _orderStorage;
    private readonly IDiscountService _discountService;
    private readonly IOrderValidation _orderValidation;

    public OrderService(IOrderStorage orderStorage, IDiscountService discountService, IOrderValidation orderValidation)
    {
        _orderStorage = orderStorage;
        _discountService = discountService;
        _orderValidation = orderValidation;
    }

    public void CreateNewOrder(int customerId, DateTime expectedDelivery, int kitQuantity, BaseDnaKit kitType)
    {
        Order order = new Order(customerId, expectedDelivery, kitQuantity, kitType);
        if (_orderValidation.IsOrderValid(order) == false)
        {
            throw new InvalidOrderException();
        }
        order.FinalOrderPrice = Math.Round(kitQuantity * kitType.Price * _discountService.DiscountCalculator(order), 2);
        _orderStorage.AddNewOrderToStorage(order);
    }
}