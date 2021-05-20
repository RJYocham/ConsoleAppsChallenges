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

        //crud
        //create
        public bool AddItemsToMenu(MenuItems newItems)
        {
            int startingCount = _menu.Count;

            _menu.Add(newItems);

            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //read
        public List<MenuItems> GetMenu()
        {
            return _menu;
        }

        //update

        //delete
    }
}
