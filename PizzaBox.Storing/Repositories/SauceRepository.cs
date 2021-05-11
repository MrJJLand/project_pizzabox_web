using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositores
{
    public class SauceRepository : IRepository<Sauce>
    {
        private readonly PizzaBoxContext _context;

        public SauceRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy(Sauce entry)
        {
            _context.Sauces.Remove(entry);
            return true;
        }

        public bool Insert(Sauce entry)
        {
            _context.Sauces.Add(entry);
            return true;
        }

        public IEnumerable<Sauce> Select(Func<Sauce, bool> filter)
        {
            return _context.Sauces.Where(filter);
        }

        public Sauce Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}