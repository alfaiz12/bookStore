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
            Checkout checkout = new Checkout();
            checkout.checkout_checkcustomer();
        }
    }
}
