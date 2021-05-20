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
            _item = new MenuItems();
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
    }
}
