using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace bookStore
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Register obj = new Register();
            //obj.get_Customer_Registered();
            //Login obj1 = new Login();
            //obj1.customer_Login();
            Categories obj = new Categories();
            obj.Cat();
        }
    }
}
