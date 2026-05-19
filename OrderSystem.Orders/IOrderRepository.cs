


using System;
using System.Collections.Generic;

namespace OrderSystem.Orders
{
    public interface IOrderRepository
    {
        void Save(Order order);

        void Add(Order order);

        List<Order> GetAll();

        Order? GetById(Guid id);
        
    }
}
