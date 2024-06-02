using System;
using System.Collections.Generic;

class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    public override string ToString()
    {
        return $"{street}\n{city}, {state}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetName()
    {
        return name;
    }

    public string GetAddress()
    {
        return address.ToString();
    }
}

class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double TotalCost()
    {
        return price * quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }
}

class Order
{
    private Customer customer;
    private List<Product> products;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public double TotalCost()
    {
        double total = 0;
        foreach (var product in products)
        {
            total += product.TotalCost();
        }
        double shippingCost = customer.IsInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string PackingLabel()
    {
        string label = "";
        foreach (var product in products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string ShippingLabel()
    {
        return $"{customer.GetName()}\n{customer.GetAddress()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Widget", "W123", 3.99, 5);
        Product product2 = new Product("Gadget", "G456", 19.99, 2);
        Product product3 = new Product("Doodad", "D789", 5.99, 10);

        // Create some addresses
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Maple St", "Toronto", "ON", "Canada");

        // Create some customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        // Create some orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Display the results for order 1
        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.PackingLabel());
        Console.WriteLine("\nOrder 1 Shipping Label:");
        Console.WriteLine(order1.ShippingLabel());
        Console.WriteLine("\nOrder 1 Total Cost: $" + order1.TotalCost());

        // Display the results for order 2
        Console.WriteLine("\nOrder 2 Packing Label:");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine("\nOrder 2 Shipping Label:");
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine("\nOrder 2 Total Cost: $" + order2.TotalCost());
    }
}
