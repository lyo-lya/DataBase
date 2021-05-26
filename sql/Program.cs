using System;
using sql.Entity;
using sql.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;



namespace sql
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductRepository repo = new ProductRepository();
            var result = repo.GetAll();
            foreach(var prod in result)
            {
                Console.WriteLine($"{prod.Name} {prod.Price}");
            }
            var newProd = new Product
            {
                Name = "Banana",
                Price = 5
            };
            repo.AddProduct(newProd);
            Console.WriteLine("------------------------------------------");
            result = repo.GetAll();
            foreach (var prod in result)
            {
                Console.WriteLine($"{prod.Name} {prod.Price}");
            }
            
        }
    }
}
