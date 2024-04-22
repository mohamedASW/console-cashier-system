using SalesSystem.Model;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Actions
{
    public  static class ProductionService
    {
        public static void Print(this Product product)
        {
            Console.WriteLine($"[{product.product_id}]-[{product.product_name}] - quantity [{product.Quantity}] -Unit Price [{product.Unitprice:c0}]");
        }

        public static void ShowProducts(this IEnumerable<Product> products)
        {
            
                foreach (var product in products)
                {
                    product.Print();
                }
           
            
        }

    }
}


