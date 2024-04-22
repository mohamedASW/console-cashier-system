using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Model
{
    public class Product
    {
        public Product(string product_id, string product_name, int quantity, decimal unitprice)
        {
            this.product_id = product_id;
            this.product_name = product_name;
            Quantity = quantity;
            Unitprice = unitprice;
        }

        

        // attributes 
        public string product_id { get; set; }
        public string product_name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Unitprice { get; set; }

        //relation

    }
}
