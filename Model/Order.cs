using SalesSystem.Repositories;

namespace SalesSystem.Model
{
    public class Order
    {
        
        //attributes
        static int autoID = -1;
        private int id;
        public int order_Id { get => id; private set => id = value; }
        public string Customer_id { get; set; }
        public DateTime OrderDate { get; set; }
        // relation
        public Customer Customer { get; set; }
        public Order(string customerid, DateTime orderDate)
        {
            order_Id = ++autoID;
            Customer_id = customerid;
            this.Customer = Repository.CustomerRepo.First(c => c.User_Id == customerid);
            OrderDate = orderDate;

        }


    }
}
