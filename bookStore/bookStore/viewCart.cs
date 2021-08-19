using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace bookStore { 
   class ViewCart
     {
        public void view_Cart(int customer_Id)
        {
            int i = 1;
            int count = 0;
            Console.WriteLine("                                                        Your Cart             ");
            var jsonString1 = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(jsonString1);
            JArray booksArrary = (JArray)jObject["addCart"];
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Sr.no      |  Customer_ID      |         BOOK NAME        |         Book_Category                            | PRICE \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            foreach (var x in booksArrary)
            {
                if (x["customer_Id"].Value<int>() == customer_Id)
                {
                    count = count + 1;
                    Console.WriteLine($"{i}    | {customer_Id}                | {x["book_Name"].Value<string>()}                                   |  {x["book_Category"].Value<string>()}                |{x["book_Price"].Value<string>()}                                   |  " );
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                    i++;
                }
            }
            if (count <= 0)
            {
                Console.WriteLine("                Your Cart is Empty                    ");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                Console.Write("Press any key to enter Mainmenu : ");
                Console.ReadLine();
                Categories cat = new Categories();
                cat.Cat();
            }
            else
            {
                //Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Choose 1:To purchase items ");
                Console.WriteLine("Choose 2:To Enter Mainmenu ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        buyNow buy = new buyNow();
                        buy.buy_from_Cart(customer_Id);
                        break;
                    case 2:
                        Main_Menu main = new Main_Menu();
                        main.mainMenu();
                        break;
                }
            }
       
        }
    }
}
