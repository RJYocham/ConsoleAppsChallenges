using _01Cafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ConsoleAppsChallenges
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuItems _item;
        private MenuItemsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemsRepo();
            _item = new MenuItems(1, "Basic Burger combo", "A plain burger with a side of fries", "lettuce, tomato, pickles", 5);
            _repo.AddItemsToMenu(_item);
        }

        [TestMethod]
        public void AddToMenu_ShouldGetCorrectBoolean()
        {
            bool addResult = _repo.AddItemsToMenu(_item);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu_ShouldReturnMenu()
        {
            List<MenuItems> menu = _repo.GetMenu();

            bool menuHasItems = menu.Contains(_item);
            Assert.IsTrue(menuHasItems);
        }

        public void ViewItem_ShouldReturnRequestedItem()
        {
            MenuItems infoRequest = _repo.GetMenuItemByName(_item);
            Assert.AreEqual(_item, infoRequest);
        }

        public void UpdateItem_ShouldReturnUpdatedInfo()
        {
            _repo.UpdateMenuItem("Basic Burger combo", new MenuItems(1, "Basic Combo", "A burger with fries", "lettuce, tomato, pickles", 5));
            Assert.AreEqual(_item.MealName, "Basic Combo");
        }

        public void DeleteItem_ShouldReturnTrue()
        {
            bool wasDeleted = _repo.DeleteMenuItem("Basic Burger combo");
            Assert.IsTrue(wasDeleted);
        }
    }
}
