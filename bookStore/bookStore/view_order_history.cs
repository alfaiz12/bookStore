using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace bookStore { 
 class ViewOrderHistory
	{
		public void View_Order_History(int customer_Id)
        {
            int i = 1;
            var jsonString2 = File.ReadAllText(@"customer_List.json");
            var jObject2 = JObject.Parse(jsonString2);
            JArray customerOrderHistoryArrary1 = (JArray)jObject2["customer_Order_History"];
            Console.WriteLine("                                                        Your Order History             ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Sr.no      |  Customer_ID      |         BOOK NAME        |         Book_Category                            | PRICE \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
            foreach (var x in customerOrderHistoryArrary1)
            {
                
                if (x["customer_Id"].Value<int>() == customer_Id)
                {
                  
                    int count = 0;
               
                    var jsonString1 = File.ReadAllText(@"customer_List.json");
                    var jObject = JObject.Parse(jsonString1);
                    JArray booksArrary = (JArray)jObject["bookDetails"];
           
                    foreach (var y in booksArrary)
                    {
                        if (y["book_Id"].Value<int>() == x["book_Id"].Value<int>())
                        {
                            count = count + 1;
                            Console.WriteLine($"{i}    | {customer_Id}                | {y["book_Name"].Value<string>()}                                   |  {y["book_Category"].Value<string>()}                |{y["book_Price"].Value<string>()}                                   |  ");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                            i = i + 1;
                        }
                    }
                    if (count <= 0)
                    {
                        Console.WriteLine("                Your Order History is Empty                    ");
                        Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------");
                        Console.Write("Press any key to enter Mainmenu : ");
                        Console.ReadLine();
                        Main_Menu main = new Main_Menu();
                        main.mainMenu();
                    }
                 
                }
            }

           
           
        }
	}
}