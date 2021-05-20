using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges_Repo
{
    public enum Doors { }
    public class Badges
    {
        public int BadgeID { get; set; }

        //List<DoorAccess> DoorAccess { get; set; }

        public Badges() { }
        public Badges(int badgeID)
        {
            BadgeID = badgeID;

        }
    }


}
