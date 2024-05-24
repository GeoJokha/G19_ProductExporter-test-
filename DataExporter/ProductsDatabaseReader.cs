using DataExporter.G19_ProductImport;
using Microsoft.Data.SqlClient;

namespace DataExporter
{
    
    public interface IProductsDatabaseReader: IDisposable
    {
        new void Dispose();
        IEnumerable<Category> GetProducts();
    }
    public class ProductsDatabaseReader(string connectionString) : Database(connectionString), IProductsDatabaseReader
    {

        //public new void Dispose()
        //{
        //    CloseConnection();
        //}
        //public IEnumerable<Product> GetProducts()
        //{
        //    List<Product> products = new();
        //    using (SqlConnection connection = OpenConnection())
        //    {
        //        string query = "SELECT Code, Name, Price FROM Products";
        //        using (SqlCommand command = GetCommand(query))
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Product product = new Product()
        //                    {
        //                        Code = reader.GetString(0),
        //                        Name = reader.GetString(1),
        //                        Price = reader.GetDecimal(2),
        //                    };
        //                    products.Add(product);
        //                }
        //            }
        //        }
        //    }

        //    return products;
        //}

        public IEnumerable<Category> GetProducts()
        {
            List<Category> products = new();
            using (SqlConnection connection = OpenConnection())
            {
                string query = "SELECT c.CategoryName, p.ProductID, p.ProductName, p.UnitPrice " +
                               "FROM Categories c " +
                               "JOIN Products p ON c.CategoryID = p.CategoryId";
                using (SqlCommand command = GetCommand(query))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Category? category = null;
                        while (reader.Read())
                        {
                            string categoryName = reader.GetString(0);
                            if (category == null || category.CategoryName != categoryName)
                            {
                                category = new Category()
                                {
                                    CategoryName = categoryName,
                                };
                                products.Add(category);
                            }

                            Product product = new Product()
                            {
                                //ProductID = reader.GetString(1),
                                ProductName = reader.GetString(2),
                                UnitPrice = reader.GetDecimal(3),
                            };

                            category.Products.Add(product);
                        }
                    }
                }
            }
            return products;
        }
    }
}
