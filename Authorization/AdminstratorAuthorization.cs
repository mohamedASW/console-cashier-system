using SalesSystem.Model;
using SalesSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Authorization
{
    public static class AdminstratorAuthorization
    {
        public static Admin LogIn(string userid)
        {
            var admin = Repository.AdminRepo.FirstOrDefault(c => c.User_Id == userid);
            if (admin is null)
                throw new InvalidDataException("invalid Admin Id ...!");
            return admin;
        }
    } 
}
