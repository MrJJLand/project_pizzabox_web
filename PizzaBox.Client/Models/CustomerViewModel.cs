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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string chooseFirstName { get; set; }
        public string chooseLastName { get; set; }

        public void Loader(UnitOfWork _uow)
        {
            FirstName = _uow.Customers.Select(c => !string.IsNullOrWhiteSpace(c.FirstName)).ToString();
            LastName = _uow.Customers.Select(c => !string.IsNullOrWhiteSpace(c.LastName)).ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (FirstName == null || LastName == null)
            {
                yield return new ValidationResult("Please fill out the Customer Name form", new string[] { "chooseFirstName", "chooseLastName" });
            }
        }
    }
}