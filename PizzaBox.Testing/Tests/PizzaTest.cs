using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class PizzaTest
    {
        public void NewPizza_Teser()
        {
            var sut = new Pizza();

            Assert.NotNull(sut);
        }
    }
}