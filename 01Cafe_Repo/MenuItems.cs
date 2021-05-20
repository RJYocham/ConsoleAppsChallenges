using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Cafe_Repo
{
    public enum Ingredients { Lettuce, Tomato, Onion }
    public class MenuItems
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public Ingredients Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItems() { }
        public MenuItems(int number, string name, string description, Ingredients ingredients, double price)
        {
            MealNumber = number;
            MealName = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
