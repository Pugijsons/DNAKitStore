using DNAKitStore.Exceptions;
using DNAKitStore.Models;

namespace DNAKitStore.Storage
{
    public class OrderStorage : IOrderStorage
    {
        private List<Order> _orderStorageList;

        public OrderStorage(List<Order> orderStorageList)
        {
            _orderStorageList = orderStorageList;
        }

        public void AddNewOrderToStorage(Order order)
        {
            if (order == null)
            {
                throw new InvalidOrderException();
            }

            _orderStorageList.Add(order);
        }

        public List<Order> FetchAllOrders()
        {
            return _orderStorageList.ToList();
        }

        public List<Order> FetchAllCustomerOrders(int customerId)
        {
            return _orderStorageList.Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
