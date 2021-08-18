using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bookStore
{
    class AfterCategories
    {

        int n = 0;
        Categories obj = new Categories();
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

                Console.WriteLine(" ID  |         BOOK NAME        |         AUTHORS                              | PRICE \n");
                foreach (var x in booksArrary)
                {
                    if (x["book_Category_id"].Value<int>() == choice)
                    {

                        Console.WriteLine($"{i}    | {x["book_Name"].Value<string>()}                | {x["book_Author"].Value<string>()}                                   |  " + (n + 1000));
                        i++;
                    }
                }
                Console.WriteLine("\nChoose The Book Of Your Liking by Entering their ID's");
                Console.WriteLine("                           OR ");
                Console.WriteLine("                    Press 0 to go Back");
                int myth1;
                myth1 = int.Parse(Console.ReadLine());

            }
        }
          
    }
}