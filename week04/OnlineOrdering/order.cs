
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }


    public double CalculateTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }


    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return label;
    }


    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";

        label += $"{_customer.GetName()}\n";
        label += _customer.GetAddress().GetFullAddress();

        return label;
    }
}