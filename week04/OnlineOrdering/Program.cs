using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("742 Evergreen Terrace", "Springfield", "Illinois", "USA");
        Customer usaCustomer = new Customer("Homer Simpson", usaAddress);
        List<Product> firstProducts = new List<Product>
        {
            new Product("Basketball", "BK201", 24.99f, 2),
            new Product("Water Bottle", "WB115", 12.50f, 1),
            new Product("Sports Towel", "ST330", 8.75f, 3)
        };
        Order firstOrder = new Order(firstProducts, usaCustomer);

        Address internationalAddress = new Address("25 Maple Road", "Toronto", "Ontario", "Canada");
        Customer internationalCustomer = new Customer("Ava Martinez", internationalAddress);
        List<Product> secondProducts = new List<Product>
        {
            new Product("Notebook Set", "NB410", 7.25f, 4),
            new Product("Gel Pens", "GP522", 5.50f, 3),
            new Product("Desk Lamp", "DL305", 18.99f, 1)
        };
        Order secondOrder = new Order(secondProducts, internationalCustomer);

        DisplayOrderDetails("Order 1", firstOrder);
        DisplayOrderDetails("Order 2", secondOrder);
    }

    static void DisplayOrderDetails(string orderTitle, Order order)
    {
        Console.WriteLine(orderTitle);
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("--------------------------------");
    }
}
