using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace bookStore
{
    class Categories
    {
        public void Cat()
        {
            Console.WriteLine("----------BOOK STORE----------");
            Console.WriteLine("\n          OVERVIEW\n");
            Console.WriteLine("A place of business where books are the main item offered for sale also called BOOK STORE.\n");
            int choice;
            Console.WriteLine("CATEGORIES OUR STORE PROVIDES\n");

            //JSON CODE
            var jsonString = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(jsonString);
            JArray categoryArrary = (JArray)jObject["categories"];
            int i = 1;
            foreach (var x in categoryArrary)
            {
                Console.WriteLine($"{i}   .  {x["book_cat"].Value<string>()}");
                i++;
            }
            //end of json code
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("\nENTER YOUR CHOICE\n");
            Console.WriteLine("          OR\n");
            Console.WriteLine("Press 0 for main menu");
            choice = int.Parse(Console.ReadLine());
            AfterCategories objects = new AfterCategories();
            objects.book_Details(choice);
        }
    }
}
