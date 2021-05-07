using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class AComponent : AModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}