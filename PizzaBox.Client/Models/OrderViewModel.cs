using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel : IValidatableObject
    {
        public List<Crust> Crusts { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Topping> Toppings { get; set; }
        public List<Sauce> Sauces { get; set; }
        public List<Cheese> Cheeses { get; set; }
        public List<Customer> Customers { get; set; }
        public List<AStore> Stores { get; set; }

        public string SelectedCrust { get; set; }
        public string SelectedSize { get; set; }
        public List<string> SelectedToppings { get; set; }
        public string SelectedCheese { get; set; }
        public string SelectedSauce { get; set; }
        public string SelectedCustomer { get; set; }
        public string SelectedStore { get; set; }

        public void Loader(UnitOfWork _uow)
        {
            Customers = _uow.Customers.Select(c => !string.IsNullOrWhiteSpace(c.Name)).ToList();
            Stores = _uow.Stores.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
            Crusts = _uow.Crusts.Select(c => !string.IsNullOrWhiteSpace(c.Name)).ToList();
            Sizes = _uow.Sizes.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
            Cheeses = _uow.Cheeses.Select(c => !string.IsNullOrWhiteSpace(c.Name)).ToList();
            Sauces = _uow.Sauces.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
            Toppings = _uow.Toppings.Select(t => !string.IsNullOrWhiteSpace(t.Name)).ToList();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedCrust == null)
            {
                yield return new ValidationResult("Please select a Crust", new string[] { "SelectedCrust" });
            }
            if (SelectedSize == null)
            {
                yield return new ValidationResult("Please select a Size", new string[] { "SelectedSize" });
            }
            if (SelectedSauce == null)
            {
                yield return new ValidationResult("Please select a Sauce", new string[] { "SelectedSauce" });
            }
            if (SelectedCheese == null)
            {
                yield return new ValidationResult("Please select a Cheese", new string[] { "SelectedCheese" });
            }
            if (SelectedCustomer == null)
            {
                yield return new ValidationResult("Please select a Customer", new string[] { "SelectedCustomer" });
            }
            if (SelectedStore == null)
            {
                yield return new ValidationResult("Please select a Store", new string[] { "SelectedStore" });
            }
            if (SelectedToppings == null || SelectedToppings.Count < 2 || SelectedToppings.Count > 5)
            {
                yield return new ValidationResult("Fix your Toppings to have at minimum 2, and maximum 5", new string[] { "SelectedToppings" });
            }
        }
    }
}