using Asignment003.DbModels;
using System;
using static System.Console;

namespace Asignment003
{
    class Program
    {
        private static readonly northwindContext _context = new northwindContext();
        static void Main(string[] args)
        {
            var products = _context.Products;

            foreach(var p in products)
            {
                WriteLine($"{p.ProductCode} {p.ProductName} {p.Description} " );
            };
            Console.WriteLine("Hello World!");
        }
    }
}
