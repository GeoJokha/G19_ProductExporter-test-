namespace DataExporter;

public class Category
{
    public string Name { get; set; } = null!;
    public ICollection<Product> Products { get; } = new List<Product>();

    public static Category GetCategory(string[] parts)
    {
        return new Category()
        {
            Name = parts[0],
        };
    }

    public override string ToString() => $"Name: {Name}";
}
