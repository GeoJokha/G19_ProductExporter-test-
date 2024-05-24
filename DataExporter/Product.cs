namespace DataExporter;

public class Product
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public static Product GetProduct(string[] parts)
    {
        return new Product()
        {
            Code = parts[2],
            Name = parts[3],
            Price = decimal.Parse(parts[4]),
        };
    }
    public override string ToString() => $"Code: {Code}, Name: {Name}, Price: {Price:0.00}";
}