using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bookStore
{
    class AfterCategories:Login
    {

        int n = 0;
        public void book_Details(int choice)
        {
            if (choice != 0)
            {
                int i = 1;
                //JSON CODE
                var jsonString = File.ReadAllText(@"customer_List.json");
                var jObject = JObject.Parse(jsonString);
                JArray booksArrary = (JArray)jObject["bookDetails"];
                foreach (var x in booksArrary)
                {
                    if (x["book_Category_id"].Value<int>() == choice)
                    {
                        Console.WriteLine($"                          Category - {x["book_Category"].Value<string>()}\n");
                        break;
                    }
                }
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(" ID  |         BOOK NAME        |                                  AUTHORS                              | PRICE \n");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                foreach (var x in booksArrary)
                {
                    if (x["book_Category_id"].Value<int>() == choice)
                    {

                        Console.WriteLine($"{i}    |{x["book_Name"].Value<string>()}                    | {x["book_Author"].Value<string>()}                                   |  {x["book_Price"].Value<int>()}");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------");
                        i++;
                    }
                }

                Console.WriteLine("Enter Book id to addtoCart / buyNow ");
                Console.WriteLine("OR choose 0 : To return previous menu");
                Console.WriteLine("");
                Console.Write("Enter here : ");
                int book_Id = int.Parse(Console.ReadLine());
                if (book_Id==0)
                {
                    Categories cat = new Categories();
                    cat.Cat();
                }
                else
                {
                    Console.WriteLine("\nChoose 1.To addtocart");
                    Console.WriteLine("\nChoose 2.To BuyNow");
                    Console.WriteLine("\nChoose 3.To mainmenu");
                    Console.WriteLine("\nChoose 4.To viewCart");
                    int option = int.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Checkout obj1 = new Checkout();
                            obj1.addtoCart(customer_id, book_Id);
                            break;
                        case 2:
                            buyNow buy = new buyNow();
                            buy.buy_Now(customer_id, book_Id);
                            break;
                        case 3:
                            Categories obj = new Categories();
                            obj.Cat();
                            break;
                        case 4:
                            ViewCart view = new ViewCart();
                            view.view_Cart(customer_id);
                            break;
                    }
                }

            }
            else
            {
                Main_Menu menu = new Main_Menu();
                menu.mainMenu();
            }
        }
          
    }
}