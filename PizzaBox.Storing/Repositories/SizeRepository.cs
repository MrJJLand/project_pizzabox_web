using System;
using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositores
{
    public class SizeRepository : IRepository<Size>
    {
        private readonly PizzaBoxContext _context;

        //public delegate bool SizeDelegate(Size size);
        public SizeRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy(Size entry)
        {
            _context.Sizes.Remove(entry);
            return true;
        }

        public bool Insert(Size entry)
        {
            _context.Sizes.Add(entry);
            return true;
        }

        public IEnumerable<Size> Select(Func<Size, bool> filter)
        {
            return _context.Sizes.Where(filter);
        }

        public Size Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}