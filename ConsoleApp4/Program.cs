using ConsoleApp4.Context;
using ConsoleApp4.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp4
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            ProductDbContext context = new ProductDbContext();
            while (true)
            {
                Console.WriteLine("1.GetAll Product");
                Console.WriteLine("2.GetById Product");
                Console.WriteLine("3.Insert Product");
                Console.WriteLine("4.Delete");
                Console.WriteLine("5.Update");

                Console.WriteLine("Choice:");
                short choice = short.Parse(Console.ReadLine());


                if (choice == 1)
                {
                    var products = await context.Products.ToArrayAsync();
                    foreach (var product in products)
                    {
                        await Console.Out.WriteLineAsync(product.Id.ToString() + "." + product.Name);
                    }

                }
                else if (choice == 2)
                {
                    Console.WriteLine("Product Id:");
                    int productId=int.Parse(Console.ReadLine());
                    var product = await context.Products.Where(p => p.Id== productId).ToListAsync();
                    product.ForEach(p => {  Console.WriteLine(p.Id.ToString()+"."+p.Name); });

                }
                else if (choice == 3)
                {
                    Console.Write("Insert product name:");
                    string productName = Console.ReadLine();

                    Console.Write("Insert product price:");
                    int productPrice=int.Parse(Console.ReadLine());

                    Console.Write("Insert catgeory id:");
                    int categoryId=int.Parse(Console.ReadLine());

                    Product newProduct = new Product
                    {
                        Name = productName,
                        Price = productPrice,
                        CategoryId = categoryId
                    };
                    await context.Products.AddAsync(newProduct);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Product inserted");

                }
                else if (choice == 4)
                {

                    Console.WriteLine("Delete Id:");
                    int prodcutId=int.Parse(Console.ReadLine());

                    var product = await context.Products.FindAsync(prodcutId);

                    if(product != null)
                    {
                        context.Products.Remove(product);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Product deleted");
                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }

                }
                else if (choice == 5)
                {
                    Console.Write("Enter product Id:");
                    int productId=int.Parse(Console.ReadLine());

                    var product = await context.Products.FindAsync(productId);
                    if(product != null) {
                        Console.Write("Enter product name:");
                        product.Name = Console.ReadLine();

                        Console.WriteLine("Enter product price:");
                        product.Price=int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter category id:");
                        product.CategoryId = int.Parse(Console.ReadLine());

                        await context.SaveChangesAsync();
                        Console.WriteLine("Product updated");


                    }
                    else
                    {
                        Console.WriteLine("Not found");
                    }

                }
              
            }
        }
    }
}
