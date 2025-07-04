using ECommerceSystem.Interfaces;

namespace ECommerceSystem.Services;

public class ShippingService
{
    public static double ProcessShipment(List<IShippable> items)
    {
        Console.WriteLine("** Shipment notice **");

        var grouped = items.GroupBy(i => i.GetName());
        double totalWeight = 0;

        foreach (var group in grouped)
        {
            int count = group.Count();
            double weight = group.First().GetWeight();
            totalWeight += weight * count;
            Console.WriteLine($"{count}x {group.Key} {weight * count * 1000}g");
        }

        Console.WriteLine($"Total package weight {totalWeight}kg");

        return totalWeight * 30;
    }
}
