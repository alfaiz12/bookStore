using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace bookStore
{
    class Checkout:Login
    {
        public void checkout_checkcustomer()
        {

  
            Console.WriteLine("1. choose to login");
            Console.WriteLine("2. new customer register here..");
            Console.WriteLine("3. If you are Admin Choose 3");
            int choose = int.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    customer_Login();
                    break;
                case 2:
                    Register obj2 = new Register();
                    obj2.get_Customer_Registered();
                    break;
                case 3:
                    Admin myobj = new Admin();
                    myobj.login_Admin();
                    break;

            }
        }
        public void addtoCart(int customer_id,int book_ids)
        {
            int Book_Id = book_ids;
            string bookName="";
            int bookPrice=0;
            string bookCategory="";
            var jsonString1 = File.ReadAllText(@"customer_List.json");
            var jObject1 = JObject.Parse(jsonString1);
            JArray bookDetailsArrary = (JArray)jObject1["bookDetails"];
            foreach (var x in bookDetailsArrary)
            {
                if (x["book_Id"].Value<int>() == Book_Id)
                {
                    bookName = x["book_Name"].Value<string>();
                    bookPrice = x["book_Price"].Value<int>();
                    bookCategory = x["book_Category"].Value<string>();
                }
            }

            var addbookCart = "{'customer_Id': " + customer_id + ", 'book_Id': " + Book_Id + ", 'book_Category': '" + bookCategory + "','book_Name': '" + bookName + "','book_Price': " + bookPrice + "}";
            var jsonString = File.ReadAllText(@"customer_List.json");
            var jsonObj = JObject.Parse(jsonString);
            var customerArray = jsonObj.GetValue("addCart") as JArray;
            var newCustomer = JObject.Parse(addbookCart);
            customerArray.Add(newCustomer);
            jsonObj["addCart"] = customerArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(@"customer_List.json", newJsonResult);
            Console.WriteLine("Book added to your cart");
            Categories obj = new Categories();
            obj.Cat();
        }


    }
}
