using SalesSystem.Authorization;
using SalesSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem
{
    static class App
    {
        public static void  welcomeScreen()
        {
            Console.WriteLine("Welcome to our sales application ");
        }
        public static User? SelectUser()
        {

            while (true)
            {
                Console.Write("Select your user type (Admin , Customer) to finish program  (exit) : ");
                userType usertype;
                var input = Console.ReadLine();
                if (input != null)
                {
                    if (Enum.TryParse(input, true, out usertype))
                    {
                        if (usertype == userType.customer)
                        {
                            Console.Write("select (Log in) or (sign up) any else word to step back : ");
                            authinticationMode mode;
                            input = Console.ReadLine();
                            if (Enum.TryParse(input, true, out mode))
                            {
                                if (mode == authinticationMode.login)
                                {
                                    var tries = 0;
                                    while (tries < 5)
                                    {
                                        Console.Write("enter customer Id : ");
                                        input = Console.ReadLine();
                                        try
                                        {
                                            return CustomerAuthorization.LogIn(input);

                                        }
                                        catch (InvalidDataException ex)
                                        {
                                            tries++;
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine($"try again [{tries}/{5}] ... ");
                                        }

                                    }

                                }
                                else
                                {

                                    var tries = 0;
                                    while (tries < 5)
                                    {
                                        Console.Write("new customer id :");
                                        var userid = Console.ReadLine();
                                        Console.Write("user name : ");
                                        var name = Console.ReadLine();
                                        try
                                        {
                                            return CustomerAuthorization.SignUp(userid, name);

                                        }
                                        catch (InvalidDataException ex)
                                        {
                                            tries++;
                                            Console.WriteLine(ex.Message);
                                            Console.WriteLine($"try again [{tries}/{5}] ... ");
                                        }

                                    }

                                }
                            }

                        }
                        else
                        {
                            int tries = 0;
                            while (tries < 5)
                            {
                                Console.Write("your admin id : ");

                                var adminid = Console.ReadLine();
                                try
                                {
                                    return AdminstratorAuthorization.LogIn(adminid);
                                }
                                catch (InvalidDataException ex)
                                {
                                    tries++;
                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine($"try again [{5 - tries}/{5}] ... ");

                                }

                            }

                        }
                    }
                    else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        return null;

                }
            }


        }

    }
}
