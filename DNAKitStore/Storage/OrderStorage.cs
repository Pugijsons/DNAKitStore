﻿using DNAKitStore.Models;

namespace DNAKitStore.Storage
{
    public class OrderStorage : IOrderStorage
    {
        private readonly List<Order> _orderStorageList;

        public OrderStorage()
        {
            _orderStorageList = new List<Order>();
        }

        public void AddNewOrderToStorage(Order order)
        {
            _orderStorageList.Add(order);
        }
    }
}
