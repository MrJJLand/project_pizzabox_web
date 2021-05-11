using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Customer : AModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName + " " + LastName}";
        }
    }
}