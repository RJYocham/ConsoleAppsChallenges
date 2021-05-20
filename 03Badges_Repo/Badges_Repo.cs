using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Badges_Repo
{
    public class Badges_Repo
    {
        private readonly Dictionary<string, List<string>> _badgeDictionary = new Dictionary<string, List<string>>(); 
        public bool AddBadge(Badge newBadge)
        {
            int startingCount = _badgeDictionary.Count;
            _badgeDictionary.Add(newBadge.BadgeID, newBadge.DoorNames);

            bool wasAdded = (_badgeDictionary.Count > startingCount) ? true : false;
            return wasAdded;
        }


        public Badge GetBadge(string badgeID)
        {
            var doorNames = _badgeDictionary[badgeID];
            return new Badge()
            {
                BadgeID = badgeID,
                DoorNames = doorNames
            };
        }

        public List<Badge> GetBadges()
        {
            var Badges = new List<Badge>();
            foreach(var Badge in _badgeDictionary)
            {
                Badges.Add(new Badge()
                {
                    BadgeID = Badge.Key,
                    DoorNames = Badge.Value
                });
            }
            return Badges;
        }

        public void UpdateBadge(Badge badge)
        {
            _badgeDictionary[badge.BadgeID] = badge.DoorNames;             
        }
    }
}
