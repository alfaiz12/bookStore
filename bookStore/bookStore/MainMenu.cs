using System;
namespace bookStore
{
    class Main_Menu:Login
    {
        public void mainMenu()
        {
            Console.WriteLine("Choose 1. Profile");
            Console.WriteLine("Choose 2. ViewProducts");
            Console.WriteLine("Choose 3. ViewCart");
            Console.WriteLine("Choose 4. ViewOrderHistory");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Profile profile = new Profile();
                    profile.profile(customer_id);
                    break;
                case 2:
                    Categories cat = new Categories();
                    cat.Cat();
                    break;
                case 3:
                    ViewCart viewcart = new ViewCart();
                    viewcart.view_Cart(customer_id);
                    break;
                case 4:
                    ViewOrderHistory orderhistory = new ViewOrderHistory();
                    orderhistory.View_Order_History(customer_id);
                    break;
            }
        }
    }
}
