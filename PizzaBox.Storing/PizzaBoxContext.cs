using Microsoft.EntityFrameworkCore;
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

        public PizzaBoxContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Crust>().HasKey(e => e.EntityID);
            builder.Entity<Size>().HasKey(e => e.EntityID);
            builder.Entity<Topping>().HasKey(e => e.EntityID);

            OnModelSeeding(builder);
        }

        private static void OnModelSeeding(ModelBuilder builder)
        {
            builder.Entity<Crust>().HasData(new Crust[]
            {
                new Crust() {EntityID = 1, Name = "Original", Price = 0.0m},
                new Crust() {EntityID = 2, Name = "Thin", Price = 1.0m},
                new Crust() {EntityID = 3, Name = "Gluten-Free", Price = 1.50m},
                new Crust() {EntityID = 4, Name = "Pretzel", Price = 1.50m},
                new Crust() {EntityID = 5, Name = "Stuffed Crust", Price = 3.0m},
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
                new Topping() {EntityID = 1, Name = "Cheese", Price = 0.0m},
                new Topping() {EntityID = 2, Name = "Marinara", Price = 0.0m},
                new Topping() {EntityID = 3, Name = "Pepperoni", Price = 1.0m},
                new Topping() {EntityID = 4, Name = "Ham", Price = 1.5m},
                new Topping() {EntityID = 5, Name = "Hawaiian", Price = 1.5m},
            });
        }
    }
}