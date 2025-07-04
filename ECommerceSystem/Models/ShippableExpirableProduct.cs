using ECommerceSystem.Interfaces;

namespace ECommerceSystem.Models;

public class ShippableExpirableProduct : ExpirableProduct, IShippable
{
    public double Weight { get; }

    public ShippableExpirableProduct(string name, double price, int quantity, DateTime expiryDate, double weight)
        : base(name, price, quantity, expiryDate)
    {
        Weight = weight;
    }

    public string GetName() => Name;
    public double GetWeight() => Weight;
}
