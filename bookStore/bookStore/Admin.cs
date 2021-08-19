using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace bookStore
{
    class Admin
    {
        public string adminPhone_Number;
        public string adminPassword;
        public bool authenticated = false;
        public void login_Admin()
        {
            Console.WriteLine("Enter Your Phone Number");
            adminPhone_Number = Console.ReadLine();
            Console.WriteLine("Enter Your Password");
            adminPassword = Console.ReadLine();

            var adminjsonString = File.ReadAllText(@"customer_List.json");
            var jObject = JObject.Parse(adminjsonString);
            JArray adminsArray = (JArray)jObject["Admins"];

            foreach (var x in adminsArray)
            {

                var phone = x["admin_Phone"].Value<string>();
                var pass = x["admin_password"].Value<string>();
                if (phone == adminPhone_Number && (pass == adminPassword))
                {
                    //customer_id = x["customer_Id"].Value<int>();
                    authenticated = true;
                    Console.WriteLine("phone"+phone+"passwod"+pass);
                }
            }
            if (authenticated == true)
            {

                modifyChoices();

            }
            else
            {
                Console.WriteLine("\nPHONE no or password is wrong");
                Console.WriteLine("Please Re-enter your credentianls\n\n");
                login_Admin();
            }
        }




        public void modifyChoices()
        {
            Console.WriteLine("1: to add books ");
            Console.WriteLine("2: to Update books");
            Console.WriteLine("3: to delete books");
            int admin_Input = int.Parse(Console.ReadLine());
            switch (admin_Input)
            {

                case 1:
                    addBooks();
                    break;
                case 2:
                    updateBooks();
                    break;
                case 3:
                    deleteBooks();
                    break;
            }
        }




        public void addBooks()
        {
            Console.WriteLine("Enter book Id ");
            int book_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter book Name ");
            string book_Name = Console.ReadLine();
            Console.WriteLine("Enter book Author ");
            string book_Author = Console.ReadLine();
            Console.WriteLine("Enter book Price ");
            int book_Price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter book Category ");
            string book_Category = Console.ReadLine();
            Console.WriteLine("Enter book Category Id");
            int bookCategory_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter book Quantity");
            int book_Quantity = int.Parse(Console.ReadLine());



            var addNewBook = "{'book_Id': " + book_Id + ", 'book_Name': '" + book_Name + "', 'book_Author': '" + book_Author + "','book_Price': " + book_Price + ",'book_Category': '" + book_Category + "','book_Category_id': " + bookCategory_Id + ",'book_Quantity': " + book_Quantity + "}";
            var jsonBookString = File.ReadAllText(@"customer_List.json");
            var jsonObj = JObject.Parse(jsonBookString);
            var bookArray = jsonObj.GetValue("bookDetails") as JArray;
            var newBook = JObject.Parse(addNewBook);
            bookArray.Add(newBook);
            jsonObj["bookDetails"] = bookArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(@"customer_List.json", newJsonResult);

            Console.WriteLine("\nTo continue in admin Panel press x ");
            Console.WriteLine("                  OR ");
            Console.WriteLine("To navigate to main menu press z");
            string adminChoice = Console.ReadLine();
            if (adminChoice == "x" || adminChoice == "X")
            {
                modifyChoices();
            }
            else if (adminChoice == "z" || adminChoice == "Z")
            {
                Checkout checkout = new Checkout();
                checkout.checkout_checkcustomer();
            }
        }    


            


        public void updateBooks()
        {
            var jsonBookString = File.ReadAllText(@"customer_List.json");
            var jsonObj = JObject.Parse(jsonBookString);
            var bookArray = jsonObj.GetValue("bookDetails") as JArray;
            foreach(var i in bookArray)
            {
                Console.WriteLine(i["book_Id"]+" |"+i["book_Name"]+" |"+ i["book_Price"]+" |"+ i["book_Quantity"]);
            }
            Console.WriteLine("\nEnter Id of book that you want to update");
            int input_book_Id = int.Parse(Console.ReadLine());
            foreach (var j in bookArray)
            {
                //stringbookid = 
                if (j["book_Id"].Value<int>() == input_book_Id)
                {
                    Console.WriteLine("Enter which property you want to Edit");
                    Console.WriteLine("1:to change Book Name ");
                    Console.WriteLine("2:to change Book Price ");
                    Console.WriteLine("3:to change Book Quantity ");
                    int editInput = int.Parse(Console.ReadLine());
                    switch (editInput)
                    {
                        case 1:
                            Console.WriteLine("Enter new Name");
                            string newName = Console.ReadLine();
                            j["book_Name"] = newName;

                            jsonObj["bookDetails"] = bookArray;
                            string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                            File.WriteAllText(@"customer_List.json", newJsonResult);
                            break;
                        case 2:
                            Console.WriteLine("Enter new Price");
                            int newPrice = int.Parse(Console.ReadLine());
                            j["book_Price"] = newPrice;

                            jsonObj["bookDetails"] = bookArray;
                            newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                            File.WriteAllText(@"customer_List.json", newJsonResult);
                            break;
                        case 3:
                            Console.WriteLine("Enter new Quantity");
                            int newQuantity = int.Parse(Console.ReadLine());
                            j["book_Quantity"] = newQuantity;

                            jsonObj["bookDetails"] = bookArray;
                            newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
                            File.WriteAllText(@"customer_List.json", newJsonResult);
                            break;

                    }

                }
            }

            Console.WriteLine("\nTo continue in admin Panel press x ");
            Console.WriteLine("              OR ");
            Console.WriteLine("To navigate to main menu press z");
            string adminChoice = Console.ReadLine();
            if (adminChoice == "x" || adminChoice == "X")
            {
                modifyChoices();
            }
            else if (adminChoice == "z" || adminChoice == "Z")
            {
                Checkout checkout = new Checkout();
                checkout.checkout_checkcustomer();
            }
        }
        public void deleteBooks()
        {
            var jsonBookString = File.ReadAllText(@"customer_List.json");
            var jsonObj = JObject.Parse(jsonBookString);
            var bookArray = jsonObj.GetValue("bookDetails") as JArray;
            foreach (var i in bookArray)
            {
                Console.WriteLine(i["book_Id"] + " |" + i["book_Name"] + " |" + i["book_Price"] + " |" + i["book_Quantity"]);
            }

            int count = 0;
            Console.WriteLine("\nEnter Id of book that you want to Delete");
            int input_book_Id = int.Parse(Console.ReadLine());
            foreach (var j in bookArray)
            {
                if (j["book_Id"].Value<int>() == input_book_Id)
                {
                    break;
                }
                count++;
            }
            bookArray[count].Remove();
            Console.WriteLine("\nYou have deleted the Item");
            jsonObj["bookDetails"] = bookArray;
            string newJsonResult = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(@"customer_List.json", newJsonResult);

            Console.WriteLine("\nTo continue in admin Panel press x ");
            Console.WriteLine("                OR ");
            Console.WriteLine("To navigate to main menu press z");
            string adminChoice = Console.ReadLine();
            if(adminChoice == "x" || adminChoice == "X")
            {
                modifyChoices();
            }
            else if(adminChoice == "z" || adminChoice == "Z")
            {
                Checkout checkout = new Checkout();
                checkout.checkout_checkcustomer();
            }


        }
    }
}
