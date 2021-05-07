using System.Collections.Generic;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositores
{
    public class PizzaRepository : IRepository<Pizza>
    {
        private readonly PizzaBoxContext _context;
        public PizzaRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy()
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Pizza entry)
        {
            _context.Pizzas.Add(entry);
            return true;
        }

        public IEnumerable<Pizza> Select(System.Func<Pizza, bool> filter)
        {
            throw new System.NotImplementedException();
        }

        public Pizza Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}