using ECommerceSystem.Interfaces;

namespace ECommerceSystem.Models;

public class Cart
{
    private List<CartItem> items = new();

    public IReadOnlyList<CartItem> Items => items;

    public void Add(Product product, int quantity)
    {
        if (quantity <= 0 || quantity > product.Quantity)
            throw new InvalidOperationException("Invalid quantity");

        items.Add(new CartItem(product, quantity));
    }

    public bool IsEmpty => !items.Any();
    public double Subtotal => items.Sum(i => i.TotalPrice);

    public List<IShippable> GetShippableItems()
    {
        return items
            .Where(i => i.Product is IShippable)
            .SelectMany(i => Enumerable.Repeat((IShippable)i.Product, i.Quantity))
            .ToList();
    }
}
