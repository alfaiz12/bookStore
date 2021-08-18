using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bookStore
{
     class Register 
    {
       
        public class Register_first
        {

            public string customer_Name { get; set; }
            public string customer_Email { get; set; }
            public int customer_Age { get; set; }
            public string customer_Phone{ get; set; }
            public string customer_Location { get; set; }
            public string customer_Password { get; set; }

        }

       
        public void get_Customer_Registered()
        {
            Console.Write("Please enter your Name: ");
            string name = Console.ReadLine();
            Console.Write("Please enter your Email: ");
            string email = Console.ReadLine();
            Console.Write("Please enter your Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Please enter your Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Please enter your Location: ");
            string location = Console.ReadLine();
            Console.Write("Please enter your Password: ");
            string password = Console.ReadLine();
            var addNewCustomer = "{ 'customer_Name': '" + name + "', 'customer_Email': '" + email + "','customer_Age': '" + age + "','customer_Phone': '" + phone + "','customer_Location': '" + location + "','customer_Password': '" + password + "'}";
            var jsonString = File.ReadAllText(@"customer_List.json");
            var jsonObj = JObject.Parse(jsonString);
            var customerArray = jsonObj.GetValue("customer") as JArray;
            var newCustomer = JObject.Parse(addNewCustomer);
            customerArray.Add(newCustomer);
            jsonObj["customer"] = customerArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObj,Formatting.Indented);
            File.WriteAllText(@"customer_List.json", newJsonResult);
            Console.WriteLine("You are successfully Registered with us");
        }

     
    }
}