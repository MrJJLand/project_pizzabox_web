using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Storing.Repositores
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly PizzaBoxContext _context;
        public CustomerRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy(Customer entry)
        {
            _context.Customers.Remove(entry);
            return true;
        }

        public bool Insert(Customer entry)
        {
            _context.Customers.Add(entry);
            return true;
        }

        public IEnumerable<Customer> Select(System.Func<Customer, bool> filter)
        {
            return _context.Customers.Where(filter);
        }

        public Customer Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}