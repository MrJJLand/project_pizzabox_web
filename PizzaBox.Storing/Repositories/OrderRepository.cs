using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositores
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly PizzaBoxContext _context;
        public OrderRepository(PizzaBoxContext context)
        {
            _context = context;
        }

        public bool Destroy(Order entry)
        {
            _context.Orders.Remove(entry);
            return true;
        }

        public bool Insert(Order entry)
        {
            _context.Orders.Add(entry);
            return true;
        }

        public IEnumerable<Order> Select(Func<Order, bool> filter)
        {
            return _context.Orders.Where(filter);
        }

        public Order Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}