using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges_Repo
{
    public enum Doors { }
    public class Badge
    {
        public string BadgeID { get; set; }

        public List<string> DoorNames { get; set; }

        public Badge() { }
        public Badge(string badgeID)
        {
            BadgeID = badgeID;

        }
    }


}
