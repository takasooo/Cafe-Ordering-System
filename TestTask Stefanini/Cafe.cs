using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestTask_Stefanini
{
    public class Cook
    {

        private string name;
        private List<Dish> cookingDishes;

        public Cook(string name)
        {

            this.name = name;
            this.cookingDishes = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            cookingDishes.Add(dish);
        }

        public void RemoveDish(Dish dish)
        {
            cookingDishes.Remove(dish);
        }

        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }
        public List<Dish> GetCookingDishes() { return cookingDishes; }

    }

    public class Dish
    {

        public string name;
        private string description;
        private decimal price;
        private int estimatedCookingTime;
        private List<Ingredient> ingredients;


        static Ingredient iPasta = new("Pasta", 3m);
        static Ingredient iCheese = new("Cheese", 1m);
        static Ingredient iMushroom = new("Mushroom", 1m);
        static Ingredient iDough = new("dough", 2m);
        static Ingredient iTomato = new("Tomato", 0.5m);
        static Ingredient iPickles = new("Pickles", 0.5m);
        static Ingredient iSalami = new("Salami", 0.5m);
        static Ingredient iSauce = new("Sauce", 2m);
        static Ingredient iLettuce = new("Lettuce", 0.5m);
        static Ingredient iPotato = new("Potato", 1m);
        static Ingredient iBun = new("Bun", 0.5m);
        static Ingredient iBeef = new("Beef", 0.5m);

        static List<Ingredient> pastaIngr = new() { iPasta, iCheese, iMushroom };
        static List<Ingredient> pizzaIngr = new() { iDough, iCheese, iMushroom, iTomato, iSalami, iSauce };
        static List<Ingredient> burgerIngr = new() { iBun, iCheese, iBeef, iTomato, iSauce, iLettuce };
        static List<Ingredient> saladIngr = new() { iLettuce, iTomato, iPickles, iMushroom, iSauce, iBeef };
        static List<Ingredient> friesIngr = new() { iPotato };

        //Dish pasta = new("Pasta", "Italian pasta with mushrooms and parmezan cheese.", 10m, 4, pastaIngr);
        //Dish pizza = new("Pizza", "Italian pizza with mushrooms and salami.", 8m, 7, pizzaIngr);
        //Dish burger = new ("Burger", "Beef burger.", 10m, 6, burgerIngr);
        //Dish salad = new ("Salad", "Warm salad with beef and mushrooms.", 6m, 3, saladIngr);
        //Dish fries = new ("Fries", "Fries.", 3m, 3, friesIngr);

        public static List<Dish> dishesMenu { get; } = new List<Dish>
        {
        new("Pasta with mushrooms", "Italian pasta with mushrooms and parmezan cheese.", 10m, 4, pastaIngr),
        new("Pizza", "Italian pizza with mushrooms and salami.", 8m, 7, pizzaIngr),
        new("Burger", "Beef burger.", 10m, 6, burgerIngr),
        new("Warm salad", "Warm salad with beef and mushrooms.", 6m, 3, saladIngr),
        new("Fries", "Fries.", 3m, 3, friesIngr)
        };

        public Dish(string name, string description, decimal price, int estimatedCookingTime, List<Ingredient> ingredients)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.estimatedCookingTime = estimatedCookingTime;
            this.ingredients = ingredients;
        }


        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }
        public string GetDescription() { return description; }
        public void SetDescription(string description) { this.description = description; }
        public decimal GetPrice() { return price; }
        public void SetPrice(decimal price) { this.price = price; }
        public int GetEstimatedCookingTime() { return estimatedCookingTime; }
        //public static int GetEstimatedCookingTime(List<Ingredient> ingredients) 
        //{

        //    switch (ingredients.Count)
        //    {
        //        case 0:
        //            return 0;
        //        case 1:
        //            return 5;
        //        case 2:
        //        case 3:
        //            return 10;
        //        case 4:
        //        case 5:
        //            return 15;
        //        case 6:
        //        case 7:
        //        case 8:
        //        case 9:
        //        case 10:
        //            return 20;
        //        default:
        //            return 30;
        //    }

        //}
        public void SetEstimatedCookingTime(int estimatedCookingTime) { this.estimatedCookingTime = estimatedCookingTime; }
        public List<Ingredient> GetIngredients() { return ingredients; }

    }

    public class Ingredient
    {

        private string name;
        private decimal price;

        public Ingredient(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public string GetName() { return name; }
        public void SetName(string name) { this.name = name; }
        public decimal GetPrice() { return price; }
        public void SetPrice(decimal price) { this.price = price; }
    }

    public class Menu
    {
        public void ShowMenu()
        {
            Console.WriteLine("Menu:");
            foreach (var dish in Dish.dishesMenu)
            {
                Console.WriteLine($"Name: {dish.name}");
                Console.WriteLine($"Description: {dish.GetDescription()}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in dish.GetIngredients())
                {
                    Console.WriteLine($"- {ingredient.GetName()}");
                }
                Console.WriteLine($"Price: ${(dish.GetPrice()) * 1.2m}");
            }
        }
    }

    public class Orders
    {

        private List<Cook> cooks;
        private Dictionary<Cook, List<Dish>> orders;
        private Dish dish;
        public Orders()
        {
            cooks = new List<Cook>()
            {
                new("Kenny"),
                new("Daniel"),
                new("Lame"),
            };
            orders = new Dictionary<Cook, List<Dish>>();
        }

        private Cook GetAvailableCook()
        {
            return cooks.OrderBy(cook => cook.GetCookingDishes().Count).FirstOrDefault();
        }

        public int TotalCookTime(Cook cook)
        {

            int totalTime = 0;
            if (orders.ContainsKey(cook))
            {
                foreach (var dish in orders[cook])
                {
                    totalTime += dish.GetEstimatedCookingTime();
                }
            }
            return totalTime;
        }

        public int OrderDish(string response)
        {

            string dishName = response.ToLower(); // Convert user input to lowercase
            foreach (var dish in Dish.dishesMenu)
            {
                if (dishName == dish.GetName().ToLower()) // Convert dish name to lowercase for comparison
                {
                    Cook availableCook = GetAvailableCook();
                    if (availableCook != null)
                    {
                        // Check if the cook already has orders
                        if (orders.ContainsKey(availableCook))
                        {
                            orders[availableCook].Add(dish);
                        }
                        else
                        {
                            orders.Add(availableCook, new List<Dish> { dish });
                        }

                        availableCook.AddDish(dish);

                        Console.WriteLine($"Ordered {dish.GetName()} to cook for {availableCook.GetName()} and it is gonna take {TotalCookTime(availableCook)} minutes.");
                        return TotalCookTime(availableCook); // Return the total estimated cooking time for the specific cook
                    }
                    else
                    {
                        Console.WriteLine("Sorry, all cooks are busy at the moment.");
                        return -1; // Indicate that all cooks are busy
                    }
                }
            }
            Console.WriteLine("Sorry, the dish you ordered is not available.");
            return -1;
        }
    }
}
