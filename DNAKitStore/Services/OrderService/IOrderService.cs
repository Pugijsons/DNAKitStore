using DNAKitStore.Models;

namespace DNAKitStore.Services.OrderService;

public interface IOrderService
{
    public void CreateNewOrder(int customerId, DateTime expectedDelivery, int kitQuantity, IBaseDnaKit kitType);
    public List<Order> ListAllCustomerOrders(int customerId);
}