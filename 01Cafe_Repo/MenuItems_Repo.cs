using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Cafe_Repo
{

    public class MenuItemsRepo
    {
        private readonly List<MenuItems> _menu = new List<MenuItems>();
                
        public bool AddItemsToMenu(MenuItems newItems)
        {
            int startingCount = _menu.Count;

            _menu.Add(newItems);

            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }
                
        public List<MenuItems> GetMenu()
        {
            return _menu;
        }

        public MenuItems GetMenuItemByName(string Name)
        {
            foreach (MenuItems item in _menu)
            {
                if(item.MealName.ToLower() == Name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
                
        public bool UpdateMenuItem(string originalInfo, MenuItems updatedInfo)
        {
            MenuItems oldInfo = GetMenuItemByName(originalInfo);

            if(oldInfo != null)
            {
                oldInfo.MealName = updatedInfo.MealName;
                oldInfo.Description = updatedInfo.Description;
                oldInfo.Ingredients = updatedInfo.Ingredients;
                oldInfo.Price = updatedInfo.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        public MenuItems GetMenuItemByName(MenuItems item)
        {
            throw new NotImplementedException();
        }
                
        public bool DeleteMenuItem(string nameToDelete)
        {
            MenuItems itemToDelete = GetMenuItemByName(nameToDelete);
            if(itemToDelete == null)
            {
                return false;
            }
            else
            {
                _menu.Remove(itemToDelete);
                return true;
            }
        }
    }
}
