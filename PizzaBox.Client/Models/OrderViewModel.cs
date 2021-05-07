using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using PizzaBox.Storing.Repositores;

namespace PizzaBox.Client.Models
{
    public class OrderViewModel : IValidatableObject
    {
        public List<Crust> Crusts { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Topping> Toppings { get; set; }

        [Required(ErrorMessage = "Select a Crust")]
        [DataType(DataType.Text)]
        public string SelectedCrust { get; set; }

        [Required(ErrorMessage = "Select a Size")]
        [DataType(DataType.Text)]
        public string SelectedSize { get; set; }

        [Required(ErrorMessage = "Select at least 2 Toppings")]
        public List<string> SelectedToppings { get; set; }

        public OrderViewModel()
        {

        }

        public void Loader(UnitOfWork _uow)
        {
            Crusts = _uow.Crusts.Select(c => !string.IsNullOrWhiteSpace(c.Name)).ToList();
            Sizes = _uow.Sizes.Select(s => !string.IsNullOrWhiteSpace(s.Name)).ToList();
            Toppings = _uow.Toppings.Select(t => !string.IsNullOrWhiteSpace(t.Name)).ToList();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //create instance of collection
            if (SelectedCrust == SelectedSize)
            {
                yield return new ValidationResult("Are you crazy!", new string[] { "SelectedCrust", "SelectedSize" });
            }

            if (SelectedToppings.Count < 2 || SelectedToppings.Count > 5)
            {
                yield return new ValidationResult("Fix your Toppings to have at minimum 2, and maximum 5", new string[] { "SelectedToppings" });
            }

            // if (SelectedCrust.Length < 100)
            // {
            //     yield return new ValidationResult("Your option is too long", new string[] { "SelectedCrust" });
            // }

            // returned instance of collection
        }
    }
}