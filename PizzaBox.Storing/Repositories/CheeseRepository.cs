using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositores
{
    public class CheeseRepository : IRepository<Cheese>
    {
        private readonly PizzaBoxContext _context;

        public CheeseRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy(Cheese entry)
        {
            _context.Cheeses.Remove(entry);
            return true;
        }

        public bool Insert(Cheese entry)
        {
            _context.Cheeses.Add(entry);
            return true;
        }

        public IEnumerable<Cheese> Select(Func<Cheese, bool> filter)
        {
            return _context.Cheeses.Where(filter);
        }

        public Cheese Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}