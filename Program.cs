using SalesSystem;
using SalesSystem.Actions;
using SalesSystem.Model;
using SalesSystem.Repositories;

App.welcomeScreen();
while (true)
{
    User? user = App.SelectUser();
    if (user == null)
    {
        Console.WriteLine("thank for using our system...");
        break;
    }
    else if (user is Customer)
    {

        var customer = (Customer)user;
        bool loggedout = false;
        while (!loggedout)
        {
            Console.WriteLine("1-make new Order ");
            Console.WriteLine("2-Get all purchases");
            Console.WriteLine("3-Get Products");
            Console.WriteLine("4-log out");
            try
            {
                Console.Write("number of your choice :  ");
                int ChoiceNumber = Convert.ToInt32(Console.ReadLine());

                switch (ChoiceNumber)
                {
                    case 1:
                        customer.MakeNewOrder();
                        break;
                    case 2:
                        customer.GetPurchases();
                        break;
                    case 3:
                        Repository.ProductRepo.ShowProducts();
                        break;
                    case 4:
                        loggedout = true;
                        break;
                    default:
                        Console.WriteLine("not valid choice");
                        break;
                }

            }
            catch
            {
            }
        }
       
    }
    else
    {
        var admin = (Admin)user;
        bool loggedout = false;
        while (!loggedout)
        {
            Console.WriteLine("1-Add new product ");
            Console.WriteLine("2-update new product");
            Console.WriteLine("3-Remove product");
            Console.WriteLine("4-Show Products");
            Console.WriteLine("5-log out");
            try
            {
                Console.Write("number of your choice :  ");
                int ChoiceNumber = Convert.ToInt32(Console.ReadLine());
                string? productid;
                switch (ChoiceNumber)
                {

                    case 1:
                        admin.AddProduct();
                        break;
                    case 2:
                        Repository.ProductRepo.ShowProducts();
                        Console.WriteLine("=================================");
                        Console.Write("Product id that you want to update (back) to cancel update process :");
                        productid = Console.ReadLine();
                        if (productid is not null)
                        {
                            if (productid.Equals("back",StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }
                            admin.UpdateProduct(productid);

                        }
                        break;
                    case 3:
                        Repository.ProductRepo.ShowProducts();
                        Console.WriteLine("=================================");
                        Console.Write("Product id that you want to remove");
                        productid = Console.ReadLine();
                        admin.RemoveProduct(productid);
                        break;
                    case 4:
                        Repository.ProductRepo.ShowProducts();
                        break;
                    case 5:
                        loggedout = true;
                        break;
                    default:
                        Console.WriteLine("not valid choice");
                        break;
                }

            }
            catch
            {
            }
        }
      

    }

}