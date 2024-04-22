using SalesSystem.Model;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Actions
{
    public static class AdminServices
    {
       public static void AddProduct(this Admin admin)
        {
            Console.Write("Enter Product ID (Back): ");
            string? productid = Console.ReadLine();
            if (productid is not null) {
                if (!productid.Equals("Back",StringComparison.OrdinalIgnoreCase) )
                {
            bool isproducthere = Repository.ProductRepo.Any(p => p.product_id == productid) ; 
                    if (isproducthere)
                    {
                        Console.Write("the product already exist , Do You want to update it ? (yes or no) : ");
                        var reader = Console.ReadLine();

                        if (reader != null)
                        {
                            if (reader.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                            {
                                var product = Repository.ProductRepo.First(p => p.product_id == productid);
                                product.Print();
                                admin.UpdateProduct(productid);
                            }
                    

                        }
               
                    }
                    else
                    {
                        Console.Write("Product name : ");
                        var productname = Console.ReadLine();
                        Console.Write("product quantity : ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        Console.Write("unit price");
                        decimal unitprice = Convert.ToDecimal(Console.ReadLine());
                        Repository.ProductRepo.Add(new Product(productid, productname, quantity, unitprice));

                    }       
             
                }
            }
            
        
        }
       public static void UpdateProduct(this Admin admin, string? productid)
        {

          var product = Repository.ProductRepo.FirstOrDefault(p => p.product_id == productid);

            if (product is not null)
            {
            again: Console.WriteLine("enter update choices seprated with comma ( , ) ");
                Console.WriteLine("your choices [productname , quantity , unitprice ]  (you can write more choice)...! [any else word to cancel update]");
                Console.Write("Your Choices : ");
                string? updatechoicereader = Console.ReadLine();
                var updatechoicesarray = updatechoicereader?.Split(',');
                if (updatechoicesarray is not null)
                {
                    UpdateChoices updatechoices = UpdateChoices.Default;
                    foreach (var updatechoice in updatechoicesarray)
                    {
                        try
                        {

                            updatechoices |= Enum.Parse<UpdateChoices>(updatechoice.Trim(), true);

                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine("you have wroten wrong choice...");
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("----------------------------------");
                            goto again;

                        }
                    }
                    if ((updatechoices & UpdateChoices.UnitPrice) != 0)
                    {
                        Console.Write("new unit price : ");
                        var price = Convert.ToDecimal(Console.ReadLine());
                        product.Unitprice = price;

                    }
                    if ((updatechoices & UpdateChoices.ProductName) != 0)
                    {
                        Console.Write("new product name : ");
                        var name = Console.ReadLine();
                        product.product_name = name ?? product.product_name;
                    }

                    if ((updatechoices & UpdateChoices.Quantity) != 0)
                    {
                        Console.Write("add on product Qunatity : ");
                        var quantity = Convert.ToInt32(Console.ReadLine());

                        product.Quantity += quantity;


                    }
                }
                else
                    goto again;
            }
            else
                Console.WriteLine("we can,t find this product");

        }
        public static void RemoveProduct(this  Admin product,string? productid)
        {
            var isvalid = Repository.ProductRepo.Any(p => p.Equals(productid));
            if (isvalid)
            {
                var prod = Repository.ProductRepo.First(p => p.product_id == productid);
                Repository.ProductRepo.Remove(prod);
            }
            else
                Console.WriteLine("sorry , we cant find this product....");
        }
        [Flags]
        enum UpdateChoices
        {
            Quantity =1 ,
            UnitPrice= 2,
            ProductName = 4 ,
            Default = 0
        }
       
    }
}
