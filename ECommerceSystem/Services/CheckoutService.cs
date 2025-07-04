using ECommerceSystem.Models;

namespace ECommerceSystem.Services;

public class CheckoutService
{
    public static void Checkout(Customer customer, Cart cart)
    {
        if (cart.IsEmpty)
            throw new InvalidOperationException("Cart is empty");

        foreach (var item in cart.Items)
        {
            if (item.Product.Quantity < item.Quantity)
                throw new InvalidOperationException($"{item.Product.Name} is out of stock");

            if (item.Product.IsExpired())
                throw new InvalidOperationException($"{item.Product.Name} is expired");
        }

        double subtotal = cart.Subtotal;
        double shipping = ShippingService.ProcessShipment(cart.GetShippableItems());
        double total = subtotal + shipping;

        if (customer.Balance < total)
            throw new InvalidOperationException("Insufficient balance");

        foreach (var item in cart.Items)
        {
            item.Product.Quantity -= item.Quantity;
        }

        customer.Balance -= total;

        Console.WriteLine("** Checkout receipt **");
        foreach (var item in cart.Items)
        {
            Console.WriteLine($"{item.Quantity}x {item.Product.Name} {item.Product.Price * item.Quantity}");
        }
        Console.WriteLine("----------------------");
        Console.WriteLine($"Subtotal {subtotal}");
        Console.WriteLine($"Shipping {shipping}");
        Console.WriteLine($"Amount {total}");
        Console.WriteLine($"Balance left {customer.Balance}");
        Console.WriteLine("END.");
    }
}
