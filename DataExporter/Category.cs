namespace DataExporter;

public class Category
{
    public string CategoryName { get; set; } = null!;
    public ICollection<Product> Products { get; } = new List<Product>();

    public static Category GetCategory(string[] parts)
    {
        return new Category()
        {
            CategoryName = parts[0],
        };
    }

    public override string ToString() => $"Name: {CategoryName}";
}
