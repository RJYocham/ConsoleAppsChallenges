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
                        //edit badge
                        break;
                    case "3":
                        //list badges
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
            Badges newBadge = new Badges();

            Console.WriteLine("What is the number on the badge?");
            newBadge.BadgeID = Convert.ToInt32(Console.ReadLine());
            bool addAccess = true;

            //add access to door
            Console.WriteLine("Any other doors? (y/n)");
            string input = Console.ReadLine();
            //loop to add more doors
        }




        private void EditBadge()
        {
            Console.Clear();
            var access = new Dictionary<int, string>()
            {
                {12345, "A7"},
                {22345, "A1, A4, B1, B2"},
                {32345, "A4, A5"}
            };
            Console.WriteLine("Which badge would you like to update?");
            int input = Convert.ToInt32(Console.ReadLine());
            if (access.ContainsKey(input))
            {
                Console.WriteLine();
            }
        }

        private void ListBadges()
        {
            Console.Clear();
            List<Badges> allBadges = _repo.GetBadge();

            foreach (Badges badge in allBadges)
            {
                Console.WriteLine(badge.BadgeID);
            }

        }
    }
}
