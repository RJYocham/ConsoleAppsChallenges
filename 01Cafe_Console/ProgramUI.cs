using _01Cafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Cafe_Console
{
    class ProgramUI
    {
        private MenuItemsRepo _repo = new MenuItemsRepo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. Create New Menu Item\n" +
                    "2. View All Menu Items\n" +
                    "3. View A Specific Item\n" +
                    "4. Update Existing Menu Items\n" +
                    "5. Delete Existing Menu Items\n" +
                    "6. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        CreateNewItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        ViewItem();
                        break;
                    case "4":
                        UpdateMenu();
                        break;
                    case "5":
                        DeleteItem();
                        break;
                    case "6":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid input. Try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewItem()
        {
            Console.Clear();
            MenuItems newItem = new MenuItems();

            Console.WriteLine("Please assign a Meal Number to this item.");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the name of the new menu item?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine($"Please describe {newItem.MealName}.");
            newItem.Description = Console.ReadLine();

            Console.WriteLine($"Please list the ingredients in {newItem.MealName}.");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine($"How much will {newItem.MealName} cost?");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            _repo.AddItemsToMenu(newItem);
        }

        private void ViewMenu()
        {
            Console.Clear();
            List<MenuItems> fullMenu = _repo.GetMenu();

            foreach(MenuItems item in fullMenu)
            {
                Console.WriteLine(item.MealName);
            }
        }

        private void ViewItem()
        {
            Console.Clear();
            ViewMenu();

            Console.WriteLine("Which item would you like to see?");
            MenuItems displayItem = _repo.GetMenuItemByName(Console.ReadLine());

            if(displayItem != null)
            {
                Console.WriteLine($"{displayItem.MealNumber} {displayItem.MealName}:\n" +
                    $"{displayItem.Description}\n" +
                    $"Ingredients: {displayItem.Ingredients}\n" +
                    $"Price: {displayItem.Price}");
            }
            else
            {
                Console.WriteLine("That item is not available.");
            }
        }

        private void UpdateMenu()
        {
            Console.Clear();
            ViewMenu();
            Console.WriteLine("Which item would you like to update?");

            string oldName = Console.ReadLine();
            MenuItems newItem = new MenuItems();

            Console.WriteLine("Please assign a new Meal Number to this item.");
            newItem.MealNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is the new name of the new menu item?");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine($"Please update the description.");
            newItem.Description = Console.ReadLine();

            Console.WriteLine($"Please update the ingredients.");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine($"What is the new price?");
            newItem.Price = Convert.ToDouble(Console.ReadLine());

            bool wasUpdated = _repo.UpdateMenuItem(oldName, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("You have successfully updated the menu.");
            }
            else
            {
                Console.WriteLine("No item by that name exists");
            }
        }

        private void DeleteItem()
        {
            Console.Clear();
            ViewMenu();

            Console.WriteLine("Which item would you like to remove from the menu?");

            bool wasDeleted = _repo.DeleteMenuItem(Console.ReadLine());
            if (wasDeleted)
            {
                Console.WriteLine("The item was successfully deleted");
            }
            else
            {
                Console.WriteLine("Item could not be deleted.");
            }
        }
    }
}
