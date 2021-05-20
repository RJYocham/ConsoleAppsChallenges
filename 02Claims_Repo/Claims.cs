using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Claims_Repo
{
    public enum ClaimType { Car = 1, Home, Theft }
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid 
        { 
            get 
            {
                double difference = DateOfClaim.Subtract(DateOfIncident).TotalDays;
                if(difference > 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            } 
        }

        public Claims() { }
        public Claims(int id, ClaimType type, string description, double amount, DateTime incident, DateTime claimDate)
        {
            ClaimID = id;
            ClaimType = type;
            Description = description;
            ClaimAmount = amount;
            DateOfIncident = incident;
            DateOfClaim = claimDate;
        }


    }
}
