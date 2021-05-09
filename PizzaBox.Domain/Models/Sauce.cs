using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Sauce : AComponent
    {
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}