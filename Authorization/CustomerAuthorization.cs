using SalesSystem.Model;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Authorization
{
    public static class CustomerAuthorization
    {
        public static Customer LogIn(string? userid)
        {
            var customr = Repository.CustomerRepo.FirstOrDefault(c => c.User_Id == userid);
            if (customr is null)
                throw new InvalidDataException("invalid customer Id ...!");
            return customr;
        }
        public static Customer SignUp(string userid, string name)
        {
            var isCustomerFound = Repository.CustomerRepo.Any(C => C.User_Id == userid);
            if (isCustomerFound)
                throw new InvalidDataException("this customer id has been used");
            var customer = new Customer(userid, name);
            Repository.CustomerRepo.Add(customer);
            return customer;

        }
    }
}
