using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Storing;
using Xunit;

namespace PizzaBox.Testing.Tests
{
    public class PizzaTest
    {
        public readonly UnitOfWork _uow;
        public void NewPizza_Teser()
        {
            var sut = new Pizza();

            Assert.NotNull(sut);
        }
        public void NewPizzaCheese()
        {
            var sut = new Pizza();
            sut.Cheese = new Cheese();
            Assert.NotNull(sut.Cheese);
        }
        public void NewPizzaSauce()
        {
            var sut = new Pizza();
            sut.Sauce = new Sauce();
            Assert.NotNull(sut.Sauce);
        }
        public void NewPizzCrust()
        {
            var sut = new Pizza();
            sut.Crust = new Crust();
            Assert.NotNull(sut.Crust);
        }
        public void NewPizzaSize()
        {
            var sut = new Pizza();
            sut.Size = new Size();
            Assert.NotNull(sut.Size);
        }
        public void NewPizzaTopping()
        {
            var sut = new Pizza();
            sut.Toppings = new List<Topping>();
            Assert.NotNull(sut.Toppings);
        }
        public void NewOrder()
        {
            var sut = new Order();
            Assert.NotNull(sut);
        }
        public void NewCustomer()
        {
            var sut = new Customer();
            Assert.NotNull(sut);
        }
        public void NewStoreC()
        {
            var sut = new ChicagoStore();
            Assert.NotNull(sut);
        }
        public void NewStoreN()
        {
            var sut = new NewYorkStore();
            Assert.NotNull(sut);
        }
        public void CheeseRep()
        {
            var sut = new Cheese();
            _uow.Cheeses.Insert(sut);
            Assert.NotNull(_uow.Cheeses);
        }

    }
}