using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositores
{
    public class ToppingRepository : IRepository<Topping>
    {
        private readonly PizzaBoxContext _context;

        // public delegate bool ToppingDelegate(Topping topping);

        public ToppingRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy(Topping entry)
        {
            _context.Toppings.Remove(entry);
            return true;
        }

        public bool Insert(Topping entry)
        {
            _context.Toppings.Add(entry);
            return true;
        }

        public IEnumerable<Topping> Select(Func<Topping, bool> filter)
        {
            return _context.Toppings.Where(filter);
        }

        public Topping Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}