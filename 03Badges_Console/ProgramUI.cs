using _03Badges_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges_Console
{
    class ProgramUI
    {
        private Badges_Repo _repo = new Badges_Repo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all Badges\n" +
                    "4. Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddNewBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListBadges();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid input");
                        break;
                }
            }
        }

        private void AddNewBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();
            newBadge.DoorNames = new List<String>();

            Console.WriteLine("What is the number on the badge?");
            newBadge.BadgeID = Console.ReadLine();

            //add access to door
            DoorAccessLoop(newBadge);
            _repo.AddBadge(newBadge);
            Console.WriteLine($"Badge {newBadge.BadgeID} added.");
        }

        private void DoorAccessLoop(Badge newBadge)
        {
            string input = "";
            //loop to add more doors
            while (input != "n")
            {
                Console.WriteLine("Add doors? (y/n)");
                input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                        AddAccessToDoor(newBadge);
                        break;
                    default:
                        Console.WriteLine("Not valid input");
                        break;
                }

            }
        }

        private void AddAccessToDoor(Badge badge)
        {
            Console.WriteLine("List a door it needs access to.");
            var doorName = Console.ReadLine();
            badge.DoorNames.Add(doorName);
            Console.WriteLine($"Access to {doorName} added");
        }

        private void RemoveAccessFromDoor(Badge badge)
        {
            Console.WriteLine("What door would you like to remove?");
            var doorName = Console.ReadLine();
            badge.DoorNames.Remove(doorName);
            Console.WriteLine($"Access to {doorName} removed");
        }




        private void EditBadge()
        {
            Console.WriteLine("What is the badge number to update?");
            var badgeNumber = Console.ReadLine();
            var badge = _repo.GetBadge(badgeNumber);
            if (String.IsNullOrEmpty(badge.BadgeID))
            {
                Console.WriteLine("Invalid badge ID.");
            }
            else
            {
                Console.WriteLine($"Badge {badge.BadgeID} has access to doors:");
                foreach (var names in badge.DoorNames)
                {
                    Console.WriteLine(names);
                };
                Console.WriteLine("What would you like to do? \n 1. Remove a door \n 2. Add a door");
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        RemoveAccessFromDoor(badge);
                        break;
                    case "2":
                        AddAccessToDoor(badge);
                        break;
                }
                _repo.UpdateBadge(badge);
            }
        }


        private void ListBadges()
        {
            Console.Clear();
            List<Badge> allBadges = _repo.GetBadges();
            foreach (Badge badge in allBadges)
            {
                Console.WriteLine($"BadgeID: {badge.BadgeID}\n" +
                    $"Access to:");
                foreach (string doorName in badge.DoorNames)
                {
                    Console.WriteLine(doorName);
                }
            }
        }
    }
}
