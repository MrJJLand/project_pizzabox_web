using System.Collections.Generic;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public class AStore : AModel
    {
        public string Name { get; set; }
        public List<Order> Orders;

        public override string ToString()
        {
            return Name;
        }

    }
}