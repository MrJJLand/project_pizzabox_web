using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
    public class CustomerViewModel : IValidatableObject
    {
        public List<Customer> Customers { get; set; }
        public string Name { get; set; }
        public string ChooseName { get; set; }
        public void Loader(UnitOfWork _uow)
        {
            Name = _uow.Customers.Select(c => !string.IsNullOrWhiteSpace(c.Name)).ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name == null)
            {
                yield return new ValidationResult("Please fill out the Customer Name form", new string[] { "chooseFirstName", "chooseLastName" });
            }
        }
    }
}