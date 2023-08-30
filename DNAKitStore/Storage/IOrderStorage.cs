using DNAKitStore.Models;

namespace DNAKitStore.Storage;

public interface IOrderStorage
{
    public void AddNewOrderToStorage(Order order);
    public List<Order> FetchAllOrders();
}