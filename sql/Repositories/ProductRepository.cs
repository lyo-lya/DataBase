using System.Collections.Generic;
using System.Linq;
using sql.Entity;
using Dapper;
using Microsoft.Data.SqlClient;


namespace sql.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetAll()
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(Setting.connectionString))
            {
                products = connection.Query<Product>("SELECT * FROM PRODUCTS").ToList();
            }

            return products;
        }

        public Product AddProduct(Product product)
        {
            using (var connection = new SqlConnection(Setting.connectionString))
            {
                connection.Execute($"INSERT INTO PRODUCTS(Name, Price) VALUES (@Name, @Price)", product);
            }

            return product;
        }

        /*public Product DeleteProduct(Product product)
        {
            using (var connection = new SqlConnection(Setting.connectionString))
            {
                connection.Execute($"DELETE FROM PRODUCTS WHERE Name='@Name'", product);
            }
            return product;
        }*/
    }
}
