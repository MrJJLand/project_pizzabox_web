using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PizzaBox.Storing.Repositores
{
    public class StoreRepository : IRepository<AStore>
    {
        private readonly PizzaBoxContext _context;
        public StoreRepository(PizzaBoxContext context)
        {
            _context = context;
        }
        public bool Destroy(AStore entry)
        {
            _context.Stores.Remove(entry);
            return true;
        }

        public bool Insert(AStore entry)
        {
            _context.Stores.Add(entry);
            return true;
        }

        public IEnumerable<AStore> Select(System.Func<AStore, bool> filter)
        {
            return _context.Stores.Where(filter);
        }

        public AStore Upgrade()
        {
            throw new System.NotImplementedException();
        }
    }
}