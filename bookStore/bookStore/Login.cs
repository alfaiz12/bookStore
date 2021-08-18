using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace bookStore
{
    class Login
    {
        public string phone_Numeer;
        public string password;
        public bool authenticated = false;
        public void customer_Login()
        {
            Console.WriteLine("Enter Your Phone Number");
            phone_Numeer = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            password = Console.ReadLine();

            var jsonString = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(jsonString);
            JArray customerArrary = (JArray)jObject["customer"];

            foreach (var x in customerArrary)
            {
                
                if(x["customer_Phone"].Value<string>() == phone_Numeer && (x["customer_Password"].Value<string>() == password))
                {
                    Console.WriteLine("Congrats you are logged in");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password or phoneno");
                    Console.WriteLine("PLease Re-enter your credintials");
                    customer_Login();
                }

            }
        }

    } 
    
}
