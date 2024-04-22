using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Model
{
    public class Order_Detail
    {
        public Order_Detail(int order_id, string product_id, int quantity, decimal unitPrice)
        {
            this.order_id = order_id;
            this.product_id = product_id;
            this.quantity = quantity;
            UnitPrice = unitPrice;
            order = Repository.OrderRepo.First(o => o.order_Id == order_id);
            product = Repository.ProductRepo.First(p=>p.product_id==product_id);
        }

        public int order_id { get; set; }
        public string  product_id { get; set; }
        public int quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order order { get; set; }
        public Product product { get; set; }
       

    }
}
