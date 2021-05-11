using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Order : AModel
    {
        public Customer Customer;
        public AStore Store;
        public List<Pizza> Pizzas;
        public decimal OrderTotal { get { return Pizzas.Sum(p => p.PizzaPrice); } }
    }
}