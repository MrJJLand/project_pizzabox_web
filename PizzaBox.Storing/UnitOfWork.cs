using PizzaBox.Storing.Repositores;

namespace PizzaBox.Storing
{
    public class UnitOfWork
    {
        public readonly PizzaBoxContext _context;
        public CrustRepository Crusts { get; }
        public SizeRepository Sizes { get; }
        public CheeseRepository Cheeses { get; }
        public SauceRepository Sauces { get; }
        public ToppingRepository Toppings { get; }
        public PizzaRepository Pizzas { get; }
        public OrderRepository Orders { get; }
        public CustomerRepository Customers { get; }
        public StoreRepository Stores { get; }

        public UnitOfWork(PizzaBoxContext context)
        {
            _context = context;
            Crusts = new CrustRepository(_context);
            Sizes = new SizeRepository(_context);
            Toppings = new ToppingRepository(_context);
            Cheeses = new CheeseRepository(_context);
            Sauces = new SauceRepository(_context);
            Pizzas = new PizzaRepository(_context);
            Orders = new OrderRepository(_context);
            Customers = new CustomerRepository(_context);
            Stores = new StoreRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}