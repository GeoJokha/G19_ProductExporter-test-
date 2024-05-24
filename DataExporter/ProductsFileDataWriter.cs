namespace DataExporter
{
    public interface IProductsFileDataWriter
    {

        void WriteProducts(IEnumerable<Category> categories, string filePath);
    }

    public class ProductsFileDataWriter : IProductsFileDataWriter
    {
        public void WriteProducts(IEnumerable<Category> categories, string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }
            
            using StreamWriter writer = new(filePath);
            foreach (Category category in categories)
            {
                writer.WriteLine(category.Name);
                foreach (Product product in category.Products)
                {
                    writer.WriteLine($"{product.Code};{product.Name};{product.Price}");
                }
            }
        }
        
    }
}
