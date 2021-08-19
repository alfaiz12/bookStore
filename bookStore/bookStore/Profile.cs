using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace bookStore
{
	public class Profile
	{
		public void profile(int customerId)
        {
			var jsonString1 = File.ReadAllText(@"customer_List.json");
			var jObject = JObject.Parse(jsonString1);
			JArray customerArrary = (JArray)jObject["customer"];
            foreach (var x in customerArrary)
            {
				if(x["customer_Id"].Value<int>() == customerId)
                {
					Console.WriteLine($"Customer Id: {x["customer_Id"].Value<int>()}");
					Console.WriteLine($"Customer Name: {x["customer_Name"].Value<string>()}");
					Console.WriteLine($"Customer Email: {x["customer_Email"].Value<string>()}");
					Console.WriteLine($"Customer Age: {x["customer_Age"].Value<int>()}");
					Console.WriteLine($"Customer Phone: {x["customer_Phone"].Value<string>()}");
					Console.WriteLine($"Customer Location: {x["customer_Location"].Value<string>()}");
				}
            }
			Console.Write("Choose any key to go in previous menu : ");
			Console.ReadLine();
			Main_Menu main = new Main_Menu();
			main.mainMenu();
		}
	}
}
