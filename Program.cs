using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using scaffolding.Data;
using scaffolding.Models;

namespace scaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //all categories
            ApplicationDbContext context = new ApplicationDbContext();
            var categories = context.Categories;
            foreach (var item in categories)
            {
                Console.WriteLine($"Name :{ item.CategoryName} Id :{item.CategoryId} ");
            }
            //first product
            ApplicationDbContext context1 = new ApplicationDbContext();
            var Product1 = context1.Products.Find(1);
            Console.WriteLine($"product name :{Product1.ProductName} product id :{Product1.ProductId}");
            //product by id 
            ApplicationDbContext context2 = new ApplicationDbContext();
            var Product2 = context2.Products.Where(e=>e.ProductId==10);
            foreach (var item in Product2)
            {
                Console.WriteLine($"ProductName :{item.ProductName} Product id :{item.ProductId}");

            }
            //all products with a model year
            ApplicationDbContext context3 = new ApplicationDbContext();
            var Product3 = context3.Products.Where(e => e.ModelYear ==2016).ToList();
            foreach (var item in Product3)
            {
                Console.WriteLine($"ProductName :{item.ProductName} Product id :{item.ProductId}");

            }
            //customer with id 
            ApplicationDbContext context4 = new ApplicationDbContext();
            var Product4 = context4.Customers.Where(e => e.CustomerId == 12);
            foreach (var item in Product4)
            {
                Console.WriteLine($"Customer Name :{item.FirstName} Customer id :{item.CustomerId}");

            }
            //product name 
            ApplicationDbContext context5 = new ApplicationDbContext();
            var Product5 = context5.Products.Include(e=>e.Brand).ToList();
            foreach (var item in Product5)
            {
                Console.WriteLine($"ProductName :{item.ProductName} Product brand :{item.Brand.BrandName}");

            }
            // count the products in specific category
            ApplicationDbContext context6 = new ApplicationDbContext();
            var Product6 = context6.Products.Where(e=>e.CategoryId==7).ToList();

            Console.WriteLine(Product6.Count);
            //calculate the total list price
            ApplicationDbContext context7 = new ApplicationDbContext();
            var Product7 = context7.Products.Where(e => e.CategoryId == 4).Max(e=>e.ListPrice);
            Console.WriteLine(Product7);
            //calculate the average list price of products 
            ApplicationDbContext context8 = new ApplicationDbContext();
            var Product8 = context8.Products.Average(e => e.ListPrice);
            Console.WriteLine(Product8);
            //orders are completed
            ApplicationDbContext context9 = new ApplicationDbContext();
            var Product9 = context9.Orders.Where(e => e.OrderStatus == 4).ToList();


        }
    }
}
