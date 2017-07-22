using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemAdminClasses;
using SystemAdminDataModel;

namespace DatabaseTesting
{
    public class Program
    {
        static void Main(string[] args)
        {
            CRUD_Operations test = new CRUD_Operations();
            //test.InsertUser("Joe", "Bloggs", "joe.bloggs@fdm.com", "abcd1234");
            //test.InsertUserAccessGroup("Admins");
            test.InsertServiceRequest("Joe Bloggs", "Password Reset", "Forgot Password");
            Console.ReadLine();
        }
    }
}
