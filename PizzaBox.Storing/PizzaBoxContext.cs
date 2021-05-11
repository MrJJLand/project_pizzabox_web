using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing
{
    public class PizzaBoxContext : DbContext
    {
        public DbSet<Crust> Crusts { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Cheese> Cheeses { get; set; }
        public DbSet<Sauce> Sauces { get; set; }
        public DbSet<AStore> Stores { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public PizzaBoxContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Order>().HasKey(e => e.EntityID);
            builder.Entity<Crust>().HasKey(e => e.EntityID);
            builder.Entity<Size>().HasKey(e => e.EntityID);
            builder.Entity<Topping>().HasKey(e => e.EntityID);
            builder.Entity<Cheese>().HasKey(e => e.EntityID);
            builder.Entity<Sauce>().HasKey(e => e.EntityID);
            builder.Entity<Pizza>().HasKey(e => e.EntityID);
            builder.Entity<AStore>().HasKey(e => e.EntityID);
            builder.Entity<Customer>().HasKey(e => e.EntityID);

            builder.Entity<ChicagoStore>().HasBaseType<AStore>();
            builder.Entity<NewYorkStore>().HasBaseType<AStore>();

            builder.Entity<Pizza>().HasOne<Crust>().WithMany();
            builder.Entity<Pizza>().HasOne<Size>().WithMany();
            builder.Entity<Pizza>().HasMany<Topping>();
            builder.Entity<Pizza>().HasOne<Sauce>().WithMany();
            builder.Entity<Pizza>().HasOne<Cheese>().WithMany();
            builder.Entity<Pizza>().HasMany<Order>().WithOne();
            builder.Entity<AStore>().HasMany<Order>(s => s.Orders).WithOne(o => o.Store);
            builder.Entity<Customer>().HasMany<Order>().WithOne(o => o.Customer);

            OnModelSeeding(builder);
        }

        private static void OnModelSeeding(ModelBuilder builder)
        {
            builder.Entity<ChicagoStore>().HasData(new ChicagoStore[]
            {
                new ChicagoStore() {EntityID = 1, Name = "Main St."},
                new ChicagoStore() {EntityID = 2, Name = "West Rd."},
                new ChicagoStore() {EntityID = 3, Name = "North Ave."},
                new ChicagoStore() {EntityID = 4, Name = "East St."},
                new ChicagoStore() {EntityID = 5, Name = "South Cir."}
            });

            builder.Entity<NewYorkStore>().HasData(new NewYorkStore[]
            {
                new NewYorkStore() {EntityID = 6, Name = "South James St."},
                new NewYorkStore() {EntityID = 7, Name = "Erie Blvd."},
                new NewYorkStore() {EntityID = 8, Name = "Black River Blvd."},
                new NewYorkStore() {EntityID = 9, Name = "Name_Pending Rd."},
                new NewYorkStore() {EntityID = 10, Name = "Artist Ln."}
            });

            builder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer() {EntityID = 1, FirstName = "Elizabeth", LastName = "Gainor"},
                new Customer() {EntityID = 2, FirstName = "Darth", LastName = "Plagueis"},
                new Customer() {EntityID = 3, FirstName = "Just", LastName = "Monika"},
                new Customer() {EntityID = 4, FirstName = "Calli", LastName = "Dream"},
                new Customer() {EntityID = 5, FirstName = "Kenneth", LastName = "Burtch"}
            });

            builder.Entity<Order>().HasData(new Order[]
            {
                new Order() {EntityID = 1}
            });

            builder.Entity<Crust>().HasData(new Crust[]
            {
                new Crust() {EntityID = 1, Name = "Original", Price = 0.0m},
                new Crust() {EntityID = 2, Name = "Thin", Price = 1.0m},
                new Crust() {EntityID = 3, Name = "Gluten-Free", Price = 1.50m},
                new Crust() {EntityID = 4, Name = "Pretzel", Price = 1.50m},
                new Crust() {EntityID = 5, Name = "Deep Dish", Price = 2.0m},
                new Crust() {EntityID = 6, Name = "Stuffed Crust", Price = 3.0m},
            });

            builder.Entity<Size>().HasData(new Size[]
            {
                new Size() {EntityID = 1, Name = "Small", Price = 10.0m},
                new Size() {EntityID = 2, Name = "Medium", Price = 13.0m},
                new Size() {EntityID = 3, Name = "Large", Price = 15.0m},
                new Size() {EntityID = 4, Name = "XL", Price = 20.0m},
            });

            builder.Entity<Topping>().HasData(new Topping[]
            {
                new Topping() {EntityID = 1, Name = "American Bacon", Price = 1.50m},
                new Topping() {EntityID = 2, Name = "Anchovies", Price = 1.50m},
                new Topping() {EntityID = 3, Name = "Avocado", Price = 1.50m},
                new Topping() {EntityID = 4, Name = "Banana Peppers", Price = 1.00m},
                new Topping() {EntityID = 5, Name = "Basil", Price = 0.50m},
                new Topping() {EntityID = 6, Name = "Bison", Price = 2.50m},
                new Topping() {EntityID = 7, Name = "Black Olives", Price = 1.00m},
                new Topping() {EntityID = 8, Name = "Breakfast Sausage", Price = 1.50m},
                new Topping() {EntityID = 9, Name = "Broccoli", Price = 1.00m},
                new Topping() {EntityID = 10, Name = "Buffalo Chicken", Price = 1.50m},
                new Topping() {EntityID = 11, Name = "Buffalo Sauce", Price = 0.50m},
                new Topping() {EntityID = 12, Name = "Canadian Bacon", Price = 2.00m},
                new Topping() {EntityID = 13, Name = "Carmalized Onions", Price = 1.00m},
                new Topping() {EntityID = 14, Name = "Chicken", Price = 1.50m},
                new Topping() {EntityID = 15, Name = "Crab", Price = 2.00m},
                new Topping() {EntityID = 16, Name = "Dill Pickles", Price = 0.50m},
                new Topping() {EntityID = 17, Name = "Eggs", Price = 1.00m},
                new Topping() {EntityID = 18, Name = "Elbows", Price = 1.00m},
                new Topping() {EntityID = 19, Name = "Elk", Price = 2.50m},
                new Topping() {EntityID = 20, Name = "Extra Cheese", Price = 0.50m},
                new Topping() {EntityID = 21, Name = "Feta", Price = 1.00m},
                new Topping() {EntityID = 22, Name = "Garlic", Price = 0.50m},
                new Topping() {EntityID = 23, Name = "Green Peppers", Price = 1.00m},
                new Topping() {EntityID = 24, Name = "Ground Beef", Price = 1.50m},
                new Topping() {EntityID = 25, Name = "Ham", Price = 1.50m},
                new Topping() {EntityID = 26, Name = "Italian Greens", Price = 1.50m},
                new Topping() {EntityID = 27, Name = "Jalepeños", Price = 1.00m},
                new Topping() {EntityID = 28, Name = "Lamb", Price = 2.50m},
                new Topping() {EntityID = 29, Name = "Lobster", Price = 3.00m},
                new Topping() {EntityID = 30, Name = "Meatball", Price = 1.50m},
                new Topping() {EntityID = 31, Name = "Mushrooms", Price = 1.00m},
                new Topping() {EntityID = 32, Name = "Pemeal Bacon", Price = 2.00m},
                new Topping() {EntityID = 33, Name = "Pepperoni", Price = 1.00m},
                new Topping() {EntityID = 34, Name = "Pesto", Price = 0.50m},
                new Topping() {EntityID = 35, Name = "Pineapple", Price = 1.00m},
                new Topping() {EntityID = 36, Name = "Prosciutto", Price = 2.00m},
                new Topping() {EntityID = 37, Name = "Pulled Pork", Price = 1.50m},
                new Topping() {EntityID = 38, Name = "Ranch", Price = 0.50m},
                new Topping() {EntityID = 39, Name = "Red Onion", Price = 1.00m},
                new Topping() {EntityID = 40, Name = "Riggie Sauce", Price = 0.50m},
                new Topping() {EntityID = 41, Name = "Salami", Price = 1.50m},
                new Topping() {EntityID = 42, Name = "Sausage", Price = 1.50m},
                new Topping() {EntityID = 43, Name = "Scallions", Price = 1.00m},
                new Topping() {EntityID = 44, Name = "Scallops", Price = 1.50m},
                new Topping() {EntityID = 45, Name = "Shaved Beef", Price = 1.50m},
                new Topping() {EntityID = 46, Name = "Shrimp", Price = 1.50m},
                new Topping() {EntityID = 47, Name = "Spinach", Price = 1.00m},
                new Topping() {EntityID = 48, Name = "Sun Dried Tomatoes", Price = 1.00m},
                new Topping() {EntityID = 49, Name = "Sweet BBQ Sauce", Price = 0.50m},
                new Topping() {EntityID = 50, Name = "Tangy BBQ Sauce", Price = 0.50m},
                new Topping() {EntityID = 51, Name = "Tomatoes", Price = 1.00m},
                new Topping() {EntityID = 52, Name = "Venison", Price = 3.00m},
                new Topping() {EntityID = 53, Name = "Yellow Onion", Price = 1.00m}
            });
            builder.Entity<Cheese>().HasData(new Cheese[]
            {
                new Cheese() {EntityID = 1, Name = "Mozzerella", Price = 0.0m},
                new Cheese() {EntityID = 2, Name = "Brie", Price = 0.0m},
                new Cheese() {EntityID = 3, Name = "Cheddar", Price = 0.0m},
                new Cheese() {EntityID = 4, Name = "Feta", Price = 0.0m},
                new Cheese() {EntityID = 5, Name = "Swiss", Price = 0.0m},
                new Cheese() {EntityID = 6, Name = "No Cheese", Price = 0.0m}
            });
            builder.Entity<Sauce>().HasData(new Sauce[]
            {
                new Sauce() {EntityID = 1, Name = "Pizza Sauce - Classic", Price = 0.0m},
                new Sauce() {EntityID = 2, Name = "Pizza Sauce - Exotic", Price = 0.0m},
                new Sauce() {EntityID = 3, Name = "Buffalo", Price = 0.0m},
                new Sauce() {EntityID = 4, Name = "Garlic Ranch", Price = 0.0m},
                new Sauce() {EntityID = 5, Name = "Marinara", Price = 0.0m},
                new Sauce() {EntityID = 6, Name = "Pesto", Price = 0.0m},
                new Sauce() {EntityID = 7, Name = "Riggie Sauce", Price = 0.0m},
                new Sauce() {EntityID = 8, Name = "Sweet BBQ", Price = 0.0m},
                new Sauce() {EntityID = 9, Name = "Tangy BBQ", Price = 0.0m},
                new Sauce() {EntityID = 10, Name = "White Garlic", Price = 0.0m}
            });
        }
    }
}