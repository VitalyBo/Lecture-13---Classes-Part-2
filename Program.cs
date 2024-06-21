using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


//Vitalii Bobyr - 06/21/24
//Programming 120 - Code Practice - Lecture 13 Classes

namespace Сonsole
{


    #region MAIN_Prog
    class Program
    {

        static FoodItem[] foodItems = new FoodItem[5];

        public static void Main(string[] args)
        {
            Preload();
            Menu();
        }

        static void Preload()
        {
            foodItems[0] = new FoodItem("Apple", 95, 7);
            foodItems[1] = new FoodItem("Banana", 105, 4);
            foodItems[2] = new FoodItem("Chicken Breast", 165, 8);
            foodItems[3] = new FoodItem("Broccoli", 55, 5);
            foodItems[4] = new FoodItem("Almonds", 70, 7);
        }

        static void DisplayAllFoodItems()
        {
            foreach (var item in foodItems)
            {
                if (item != null)
                {
                    Console.WriteLine(item.DisplayInformation());
                    Console.WriteLine();
                }
            }
        }

        static FoodItem MakeNewItem()
        {
            Console.Write("Enter the name of the new food item: ");
            string name = Console.ReadLine();

            int calories;
            while (true)
            {
                Console.Write("Enter the number of calories: ");
                if (int.TryParse(Console.ReadLine(), out calories))
                    break;
                else
                    Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            int quantity;
            while (true)
            {
                Console.Write("Enter the quantity: ");
                if (int.TryParse(Console.ReadLine(), out quantity))
                    break;
                else
                    Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            return new FoodItem(name, calories, quantity);
        }

        static int FindEmptyIndex()
        {
            for (int i = 0; i < foodItems.Length; i++)
            {
                if (foodItems[i] == null)
                    return i;
            }
            return -1;
        }

        static void IncreaseArraySize()
        {
            FoodItem[] newArray = new FoodItem[foodItems.Length * 2];
            for (int i = 0; i < foodItems.Length; i++)
            {
                newArray[i] = foodItems[i];
            }
            foodItems = newArray;
        }

        public static void AddItem()
        {
            FoodItem newItem = MakeNewItem();

            int firstIndex = FindEmptyIndex();

            if (firstIndex == -1)
            {
                IncreaseArraySize();
                firstIndex = FindEmptyIndex();
            }

            foodItems[firstIndex] = newItem;
        }



        #endregion


        #region Menu
        static void Menu()
        {


        start:
            while (true)
            {
                try
                {

                    Console.WriteLine("Menu Options:");
                    Console.WriteLine("1. Display all the calories you have eaten");
                    Console.WriteLine("2. Add New Items");
                    Console.WriteLine("3. Double the size of the array");
                    Console.WriteLine("4. Exit");
                    Console.Write("Please select an option (1-4): ");

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1: DisplayAllFoodItems(); break;
                            case 2: AddItem(); break;
                            case 3: IncreaseArraySize(); break;
                            case 4: return;
                            default: Console.WriteLine("Invalid option. Please select a number between 1 and 7."); break;
                        }
                    }
                    else { Console.WriteLine("Invalid input. Please enter a number between 1 and 7."); }
                }

                catch
                {
                    Console.WriteLine("OOooooooopsssss something going wrong try again!!!!");
                    goto start;
                }


            }



        }
        #endregion


        #region FoodItem_Class
        class FoodItem
        {
            public string Name;
            public int Calories;
            public int Quantity;

            public FoodItem()
            {
                Name = "No Item Listed";
                Calories = -1;
                Quantity = -1;
            }

            public FoodItem(string name, int calories, int quantity)
            {
                Name = name;
                Calories = calories;
                Quantity = quantity;
            }

            public double TotalCalories()
            {
                return Calories * Quantity;
            }

            public string DisplayInformation()
            {
                return $"Name: {Name}\nCalories: {Calories}\nQuantity: {Quantity}\nTotal Calories: {TotalCalories()}";
            }
        }
        


    }
    #endregion
}