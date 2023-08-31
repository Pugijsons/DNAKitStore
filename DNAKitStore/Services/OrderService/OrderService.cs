using DNAKitStore.Models;
using DNAKitStore.Services.DiscountService;
using DNAKitStore.Storage;
using DNAKitStore.Validation;
using DNAKitStore.Exceptions;
using DNAKitStore.Services.DiscountCalculator;

namespace DNAKitStore.Services.OrderService;

public class OrderService
{
    private readonly IOrderStorage _orderStorage;
    private readonly IOrderValidation _orderValidation;
    private readonly IDiscountCalculator _discountCalculator;

    public OrderService(IOrderStorage orderStorage, IOrderValidation orderValidation, IDiscountCalculator discountCalculator)
    {
        _orderStorage = orderStorage;
        _orderValidation = orderValidation;
        _discountCalculator = discountCalculator;
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
        ApplyDiscount(order);
        _orderStorage.AddNewOrderToStorage(order);
    }

    public decimal CalculateFinalPrice(Order order)
    {
        return order.KitQuantity * order.KitType.Price;
    }

    public void ApplyDiscount(Order order)
    {
        decimal finalPrice = CalculateFinalPrice(order);
        order.FinalOrderPrice *= _discountCalculator.CalculateDiscount(finalPrice, order.KitQuantity);
    }

    public void ListAllOrders()
    {
        var orderList = _orderStorage.FetchAllOrders();
        if (orderList.Count == 0)
        {
            Console.WriteLine("No orders placed yet!");
        }
        foreach (var order in orderList)
        {
            Console.WriteLine($"Customer: {order.CustomerId}, kit selected: {order.KitType.DnaKitToString()}, price per item: {order.KitType.Price}, quantity: {order.KitQuantity}, final price: {order.FinalOrderPrice}.");
        }
    }
}