using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Cheese : AComponent
    {
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}