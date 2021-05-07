using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Pizza : AModel
    {
        public string Name = "";
        public Order order;
        public Crust Crust;
        public Size Size;
        public List<Topping> Toppings;
        public long CrustEntityID;
        public long SizeEntityID;
        public long ToppingEntityID;
        public decimal PizzaPrice { get { return Crust.Price + Size.Price + Toppings.Sum(t => t.Price); } }
    }
}