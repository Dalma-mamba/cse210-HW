
class Program
{
    static void Main(string[] args)
    {

        // ORDER 1
        Address address1 = new Address(
            "123 Main Street",
            "New York",
            "NY",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );


        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Laptop",
            "L001",
            900,
            1
        );

        Product product2 = new Product(
            "Mouse",
            "M001",
            25,
            2
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);



        // ORDER 2
        Address address2 = new Address(
            "45 London Road",
            "London",
            "England",
            "UK"
        );


        Customer customer2 = new Customer(
            "Maria Brown",
            address2
        );


        Order order2 = new Order(customer2);


        Product product3 = new Product(
            "Phone",
            "P001",
            600,
            1
        );


        Product product4 = new Product(
            "Headphones",
            "H001",
            80,
            1
        );


        order2.AddProduct(product3);
        order2.AddProduct(product4);



        // DISPLAY ORDERS

        Console.WriteLine("ORDER 1");
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Console.WriteLine("\n----------------------------\n");


        Console.WriteLine("ORDER 2");
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");

    }
}