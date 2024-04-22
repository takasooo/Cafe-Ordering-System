using System;
using TestTask_Stefanini;

class Program
{
    static void Main(string[] args)
    {

        Menu menu = new Menu();
        Orders orders = new Orders();

        bool ordering = true;

        while (ordering)
        {
            menu.ShowMenu();

            Console.Write("Enter the dish you want to order (or type 'exit' to quit): ");
            string dishName = Console.ReadLine().Trim();

            if (dishName.ToLower() == "exit")
            {
                ordering = false;
                continue;
            }

            int totalCookTime = orders.OrderDish(dishName);

            if (totalCookTime != -1)
            {
                Console.WriteLine($"Total estimated cooking time: {totalCookTime} minutes.");
            }
            else
            {
                Console.WriteLine("Order could not be placed. Please try again.");
            }

            Console.Write("Do you want to order another dish? (yes/no): ");
            string anotherOrder = Console.ReadLine().Trim().ToLower();

            if (anotherOrder != "yes")
            {
                ordering = false;
            }
        }

        Console.WriteLine("Thank you for using our ordering system. Press any key to exit.");
        Console.ReadKey();
    }
}