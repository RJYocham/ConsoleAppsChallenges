using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges_Repo
{
    public class Badges_Repo
    {
        private readonly List<Badges> _badgeDirectory = new List<Badges>();
        public bool AddBadge(Badges newBadge)
        {
            int startingCount = _badgeDirectory.Count;
            _badgeDirectory.Add(newBadge);

            bool wasAdded = (_badgeDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //public Dictionary<int, List<string>> _doorAccess = new Dictionary<int, List<string>>();


        public List<Badges> GetBadge()
        {
            return _badgeDirectory;
        }

        //update badge access

        //delete badge access
    }
}
