using ECommerceSystem.Models;
using ECommerceSystem.Services;

namespace ECommerceSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cheese = new ShippableExpirableProduct("Cheese", 100, 10, DateTime.Now.AddDays(2), 0.2);
            var biscuits = new ExpirableProduct("Biscuits", 150, 5, DateTime.Now.AddDays(2));
            var tv = new ShippableProduct("TV", 3000, 2, 5);
            var scratchCard = new SimpleProduct("Mobile Scratch Card", 50, 20);


            var customer = new Customer("Ahmed", 1000);
            var cart = new Cart();

            cart.Add(cheese, 2);
            cart.Add(biscuits, 1);
            cart.Add(scratchCard, 1);

            CheckoutService.Checkout(customer, cart);

        }
    }
}
