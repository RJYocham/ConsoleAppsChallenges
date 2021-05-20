using _02Claims_Repo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Claims_Console
{
    class ProgramUI
    {
        private Claims_Repo _repo = new Claims_Repo();
        public void Run()
        {
            SeedClaimsList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("What would you like to do?\n" +
                    "1. Add A Claim\n" +
                    "2. See All Claims\n" +
                    "3. Take Care Of Next Claim\n" +
                    "4. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewClaim();
                        break;
                    case "2":
                        DisplayAllClaims();
                        break;
                    case "3":
                        ClaimQueueNext();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid input.");
                        break;
                }
            }

        }

        Queue claimsQueue = new Queue();

        private void CreateNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();
            List<Claims> allClaims = _repo.GetClaims();

            Console.WriteLine("Please enter an ID -number- for the claim.");
            int input = Convert.ToInt32(Console.ReadLine());

            foreach (Claims claim in allClaims)
            {
                if (input == claim.ClaimID)
                {
                    Console.WriteLine("This ID is already taken. Please choose a different ID");
                }
                else
                {
                    newClaim.ClaimID = input;
                }
            }

            Console.WriteLine("Enter the Type of Claim:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");
            newClaim.ClaimType = (ClaimType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please describe the claim:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("How much is the claim for?");
            newClaim.ClaimAmount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("What was the date of the incident? (yyyy/mm/dd)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            newClaim.DateOfClaim = DateTime.Today;

            bool isadded = _repo.AddClaim(newClaim);
            if (isadded)
            {
                claimsQueue.Enqueue(newClaim);
                Console.WriteLine("Claim was successfully added");
            }
            else
            {
                Console.WriteLine("Error adding claim.");
            }
        }

        public void DisplayAllClaims()
        {
            Console.Clear();

            foreach (Claims claim in claimsQueue)
            {
                Console.WriteLine($"{claim.ClaimID} {claim.ClaimType}\n" +
                    $"{claim.Description}\n" +
                    $"{claim.ClaimAmount}\n" +
                    $"{claim.DateOfIncident} {claim.DateOfClaim}\n" +
                    $"{claim.IsValid}\n" +
                    $"");
            }
        }

        public void DisplayNextClaim(Claims claim)
        {
            Console.Clear();
            Console.WriteLine($"{claim.ClaimID} {claim.ClaimType}\n" +
                                $"{claim.Description}\n" +
                                $"{claim.ClaimAmount}\n" +
                                $"{claim.DateOfIncident} {claim.DateOfClaim}\n" +
                                $"{claim.IsValid}\n" +
                                $"");
        }

        public void ClaimQueueNext()
        {
            Console.Clear();
            //display next claim info by claim position
            DisplayNextClaim((Claims)claimsQueue.Peek());

            Console.WriteLine("Do you want to deal with this claim now? (y/n)");
            string input = Console.ReadLine();

            switch (input)
            {
                case "y":
                    claimsQueue.Dequeue();
                    break;
                case "n":
                    Menu();
                    break;
                default:
                    Console.WriteLine("not a valid input");
                    break;
            }
        }


        //premaidclaims add stuff! fix datetimes
        private void SeedClaimsList()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Car accident on 465.", 400, DateTime.Parse("2018,04,25"), DateTime.Parse("2018/04/27"));
            Claims claimTwo = new Claims(2, ClaimType.Home, "House fire in kitchen.", 4000, DateTime.Parse("2018/04/11"), DateTime.Parse("2018/04/12"));
            Claims claimThree = new Claims(3, ClaimType.Theft, "Stolen pancakes.", 4, DateTime.Parse("2018/04/27"), DateTime.Parse("2018/06/01"));
            claimsQueue.Enqueue(claimOne);
            claimsQueue.Enqueue(claimTwo);
            claimsQueue.Enqueue(claimThree);
        }
    }
}
