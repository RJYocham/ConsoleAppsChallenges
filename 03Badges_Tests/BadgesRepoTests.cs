using _03Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace _03Badges_Tests
{
    [TestClass]
    public class BadgeTests
    {
        [TestMethod]
        public void AddBadgeTest_ShouldAddBadge()
        {
            var _badgeRepo = new Badges_Repo();
            var badge = new Badge() {
                BadgeID = "123",
                DoorNames = new List<String>() { 
                "door1",
                "door2"
                }
            };
            var isAdded = _badgeRepo.AddBadge(badge);
            Assert.IsTrue(isAdded); 
        }

        [TestMethod]
        public void EditBadgeTest_ShouldAddDoors()
        {
            var _badgeRepo = new Badges_Repo();
            var badge = new Badge()
            {
                BadgeID = "123",
                DoorNames = new List<String>() {
                "door1",
                "door2"
                }
            };
            _badgeRepo.AddBadge(badge); 

            var updatedBadge = new Badge()
            {
                BadgeID = "123",
                DoorNames = new List<String>() {
                "door1",
                "door2",
                "door3"
                }
            };

            _badgeRepo.UpdateBadge(updatedBadge);
            var testBadge = _badgeRepo.GetBadge("123");
            Assert.AreEqual(testBadge.DoorNames.Count, 3); 
        }

        [TestMethod]
        public void EditBadgeTest_ShouldRemoveDoors()
        {
            var _badgeRepo = new Badges_Repo();
            var badge = new Badge()
            {
                BadgeID = "123",
                DoorNames = new List<String>() {
                "door1",
                "door2"
                }
            };
            _badgeRepo.AddBadge(badge);

            var updatedBadge = new Badge()
            {
                BadgeID = "123",
                DoorNames = new List<String>() {
                "door1",
                }
            };

            _badgeRepo.UpdateBadge(updatedBadge);
            var testBadge = _badgeRepo.GetBadge("123");
            Assert.AreEqual(testBadge.DoorNames.Count, 1);
        }
    }
}
