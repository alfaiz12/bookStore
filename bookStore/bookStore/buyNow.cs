using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace bookStore { 
    class buyNow
    {
        public void buy_Now(int customer_Id,int book_Id)
        {
            int book_Price=0;
            var addNewCustomer = "{'customer_Id': " + customer_Id + ", 'book_Id': " + book_Id + "}";
            var jsonString = File.ReadAllText(@"customer_List.json");
            var jsonObj = JObject.Parse(jsonString);
            var customerArray = jsonObj.GetValue("customer_Order_History") as JArray;
            var newCustomer = JObject.Parse(addNewCustomer);
            customerArray.Add(newCustomer);
            jsonObj["customer_Order_History"] = customerArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(@"customer_List.json", newJsonResult);
            // get book price and reduce quantity
            var jsonString1 = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(jsonString1);
            JArray booksArrary = (JArray)jObject["bookDetails"];
            foreach(var x in booksArrary)
            {
                if(x["book_Id"].Value<int>() == book_Id)
                {
                    book_Price = x["book_Price"].Value<int>();
                    int a = x["book_Quantity"].Value<int>();
                    x["book_Quantity"] = a - 1;
                }
            }
            jObject["bookDetails"] = booksArrary;
            string output = JsonConvert.SerializeObject(jObject,Formatting.Indented);
            File.WriteAllText(@"customer_List.json", output);
            //end----------------------------------------------------------------------

            Console.WriteLine($"Your total bill is {book_Price}");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Thankyou for visiting us");
        }

        public void buy_from_Cart(int customer_Id)
        {
            int total = 0;
            var jsonString1 = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(jsonString1);
            JArray booksArrary = (JArray)jObject["addCart"];
            foreach(var x in booksArrary)
            {
                if (x["customer_Id"].Value<int>() == customer_Id)
                {
                    int bookId = x["book_Id"].Value<int>();
                    //ADDING CART ITEMS TO ORDER HISTORY ---------------------------------------------------------------------------
                    var addNewOrderhistory = "{'customer_Id': " + customer_Id + ", 'book_Id': " + x["book_Id"].Value<int>() + "}";
                    var jsonString = File.ReadAllText(@"customer_List.json");
                    var jsonObj = JObject.Parse(jsonString);
                    var customerOrderhistoryArray = jsonObj.GetValue("customer_Order_History") as JArray;
                    var newOrder = JObject.Parse(addNewOrderhistory);
                    customerOrderhistoryArray.Add(newOrder);
                    jsonObj["customer_Order_History"] = customerOrderhistoryArray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                    File.WriteAllText(@"customer_List.json", newJsonResult);
                    //END ------------------------------------------------------------------------------------------------------------

                    //  reduce book quantity---------------------------------------------------------
                    var jsonString2 = File.ReadAllText(@"customer_List.json");
                    var jObject1 = JObject.Parse(jsonString2);
                    JArray booksArrary1 = (JArray)jObject1["bookDetails"];
                    foreach (var y in booksArrary1)
                    {
                        if (y["book_Id"].Value<int>() == bookId)
                        {
                            total = total + y["book_Price"].Value<int>();
                            int a = y["book_Quantity"].Value<int>();
                            y["book_Quantity"] = a - 1;
                        }
                    }
                    jObject1["bookDetails"] = booksArrary1;
                    string output1 = JsonConvert.SerializeObject(jObject1, Formatting.Indented);
                    File.WriteAllText(@"customer_List.json", output1);
                    //end--------------------------------------------------------------------------

                    //remove items cart----------------------------------------------------------------
                    var jsonString3 = File.ReadAllText(@"customer_List.json");
                    var jObject3 = JObject.Parse(jsonString3);
                    JArray cartitemsArrary1 = (JArray)jObject3["addCart"];
                    var itemToDeleted = cartitemsArrary1.FirstOrDefault(obj => obj["customer_Id"].Value<int>() == customer_Id);
                    cartitemsArrary1.Remove(itemToDeleted);
                    string output3 = JsonConvert.SerializeObject(jObject3, Formatting.Indented);
                    File.WriteAllText(@"customer_List.json", output3);
                    //end------------------------------------------------------------------------------------

                  
                }
            }

            Console.WriteLine($"Your total bill {total}");
        }
    }
}
