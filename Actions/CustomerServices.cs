using SalesSystem.EnhancedModel;
using SalesSystem.Model;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SalesSystem.Actions
{
    public static class CustomerServices 
    {
 
        public static void GetPurchases(this Customer customr)
        {

            var orders = Repository.OrderRepo.Where(o => o.Customer_id == customr.User_Id);

            var detailedorders = orders.GroupJoin(Repository.Order_DetailRepo, o => o.order_Id, od => od.order_id, (o, od) => new
            {
                OrderInfos =
                od.Select(e => new OrderInfo { OrderDate = o.OrderDate, ProductName = e.product.product_name, Quantity = e.quantity, UnitPrice = e.UnitPrice }
                ),
                order_id = o.order_Id
            });
                                 
            foreach ( var detailedorder in detailedorders )
            {
                Console.WriteLine($"Order ID : {detailedorder.order_id}");
                Console.WriteLine("------------------------------");
                foreach (var  orderinfo in detailedorder.OrderInfos)
                {
                    Console.WriteLine(orderinfo);
                }
                Console.WriteLine("---------------------------------");
            }
        }

        
        public static  void MakeNewOrder(this Customer customer )
        {
            // create new Order 
            var neworder = new Order(customer.User_Id,DateTime.Now);
            // show products and its quantities to complete ordering
            
            
            Repository.OrderRepo.Add(neworder);
            Repository.ProductRepo.ShowProducts();
            // choose products 
            var order_details = determineProducts(neworder.order_Id);
            // add to card
            if ( order_details.Count!=0)
            {
                foreach (var item in order_details)
                {
                    item.product.Quantity -= item.quantity;
                }
            Repository.Order_DetailRepo.AddRange(order_details);
            } 
            
        }

        private static List<Order_Detail> determineProducts(int orderid)
        {
            List<Order_Detail> order_Details = new List<Order_Detail>();
            Console.Write("Enter products id that yo want and valid quantity like [productID-quantity , productId-quantity ] : ");
            var Readproducts = Console.ReadLine();
            if (Readproducts is not null)
            {
                var products = Readproducts.Split(',');
                foreach (var item in products)
                {
                    var productIdwithQuantity = item.Trim().Split('-');
                    var productid = productIdwithQuantity[0].Trim();
                    var isProductidIsValid = Repository.ProductRepo.Any(p => p.product_id == productid);

                    if (isProductidIsValid)
                    {
                        try
                        {
                        var quantity = Convert.ToInt32(productIdwithQuantity[1].Trim());
                        var product = Repository.ProductRepo.First(p => p.product_id == productid);
                        var isquantityvalid = (quantity < product.Quantity) && (quantity > 0);
                        if (isquantityvalid)
                        {
                            var isaddedbefore = order_Details.FirstOrDefault(o=>o.product_id==productid);
                            if (isaddedbefore is  null)
                            {
                             order_Details.Add(new Order_Detail(orderid, productid, quantity, product.Unitprice));
                            }

                        }

                        }
                        catch
                        {

                           
                        }
                    }
                }
            }
           return order_Details;
        }

    }
}
