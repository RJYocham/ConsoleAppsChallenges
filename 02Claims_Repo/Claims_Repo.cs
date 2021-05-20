using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Claims_Repo
{
    public class Claims_Repo
    {
        private readonly List<Claims> _claimDirectory = new List<Claims>();
        //crud
        public bool AddClaim(Claims newClaim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Add(newClaim);

            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Claims> GetClaims()
        {
            return _claimDirectory;
        }


        //get individual claim by que **figure out how to add que

        //take care of next claim
        //public bool RemoveClaimFromQueue()
        //{
        //    bool wasRemoved = _repo.RemoveClaimFromQueue();
        //    if (wasRemoved)
        //    {
        //        Console.WriteLine("You have successfully completed the claim");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Claim could not be completed");
        //    }
        //}

        //delete claim
    }
}
