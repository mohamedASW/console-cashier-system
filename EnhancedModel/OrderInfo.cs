using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.EnhancedModel
{
    public class OrderInfo
    {
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return $"[{ProductName}]-[{Quantity}]-[{UnitPrice:c0}]-[{OrderDate.Date}] ";
        }

    }
}
