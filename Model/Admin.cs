using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesSystem.Model
{
    public class Admin : User
    {
        public Admin(string userid, string name) : base(userid, name)
        {
        }
    }
}
