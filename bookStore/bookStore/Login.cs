using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace bookStore
{
    class Login
    {
        public static int customer_id;
        public string phone_Number;
        public string password;
        public bool authenticated = false;
        public void customer_Login()
        {
           
            Console.WriteLine("Enter Your Phone Number");
            phone_Number = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            password = Console.ReadLine();

            var jsonString = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(jsonString);
            JArray customerArrary = (JArray)jObject["customer"];

            foreach (var x in customerArrary)
            {
            
                var phone = x["customer_Phone"].Value<string>();
                var pass =  x["customer_Password"].Value<string>();
                if (phone == phone_Number && (pass == password))
                {
                    customer_id = x["customer_Id"].Value<int>();
                    authenticated = true;
                }
            }
            if(authenticated == true)
            {
                Main_Menu main = new Main_Menu();
                main.mainMenu();
                //Categories obj = new Categories();
                //obj.Cat();
            }
            else
            {
                Console.WriteLine("PHONE no or password is wrong");
                Console.WriteLine("Please Re-enter your credentianls");
                customer_Login();
            }
        }

    } 
    
}
