using ConsoleApp4.Context;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp4
{
    internal class Program
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


                if(choice == 1) { 
                    var products=await context.Products.ToArrayAsync();
                    foreach (var product in products)
                    {
                        await Console.Out.WriteLineAsync(product.Id.ToString() +"."+ product.Name);
                    }
                
                }
                else if(choice == 2)
                {

                }








            }
        }
    }
}
