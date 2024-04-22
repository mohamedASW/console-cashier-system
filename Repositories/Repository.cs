using SalesSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Repositories
{
    public class Repository
    {
        public readonly static List<Customer> CustomerRepo = new List<Customer>() {
        new Customer("Mohamed@Customer2003","mohamed "),
        new Customer("Hemdan@Customer2003","hemdan")
        
        };
        public static readonly List<Order> OrderRepo = new List<Order>();
        public static readonly List<Admin> AdminRepo = new List<Admin>()
        {
            new Admin ("Mohamed@Admin2003","mohamed ahmed abd al alem") ,
            new Admin("Hemdan@Admin2003","Hemdan mohamed hemdan Nada")

        };
        public static readonly List<Product> ProductRepo = new List<Product>() {
           new Product("p101","PEPSI",100,20),
           new Product("p102","Coca Cola",100,15),
           new Product("c101","Shepsi",100,10)

        };
        public static readonly List<Order_Detail>Order_DetailRepo = new List<Order_Detail>();
    }
}
