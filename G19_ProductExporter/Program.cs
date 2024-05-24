using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.IO;
using System.Linq;
using DataExporter;
using Microsoft.Data.SqlClient;


namespace G19_ProductExporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string filePath = @"D:\products.txt";
            const string connectionString = "Server=DESKTOP-ANU2LNI;Database=NorthWind;Integrated Security=true;TrustServerCertificate=true";
            ProductsDatabaseReader reader = new(connectionString);
            ProductsFileDataWriter writer = new();
            writer.WriteProducts(reader.GetProducts(), filePath);
            try 
            {
                foreach (Category category in reader.GetProducts())
                {
                    Console.WriteLine(category);
                    foreach (Product product in category.Products)
                    {
                        Console.WriteLine(product);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                reader.Dispose();
            }
        }
    }
}
