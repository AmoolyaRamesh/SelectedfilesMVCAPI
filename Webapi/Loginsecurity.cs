using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAoi.Models;

namespace WebAoi
{
    public class Loginsecurity
    {
        public static bool login(string username, string password)
        {
            masterEntities db = new masterEntities();
            {
                return db.users.Any(x => x.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password);
            }

        }
    }
}