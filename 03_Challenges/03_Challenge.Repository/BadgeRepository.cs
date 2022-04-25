using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class BadgeRepository
    {
        private readonly Dictionary<int, Badge> BadgeList  = new Dictionary<int, Badge>();
        // private readonly Dictionary<int, List<doors>> DoorList = Dictionary<int, List<doors>>();
        private int _count = 0;
        public bool AddBadgeList(Badge badge)
        {
            if (badge != null)
            {
                _count++;
                badge.ID = _count;
                BadgeList.Add(badge.ID, badge);
                return true;
            }
            return false;
        }
 
        public Dictionary<int, Badge> GetAllBadgesAndDoors()
        {
            return BadgeList; 
        }

        public Badge GetBadgeByKey(int badgeId)
        {
            foreach (var badge in BadgeList)
            {
                if(badge.Key==badgeId)
                return badge.Value;
            }
            return null;
        }
        public bool AddDoor(int badgeID,string doorName)
        {
            var badgeForDoorUpdate= GetBadgeByKey(badgeID);
            if(badgeForDoorUpdate is null)
            return false;

            badgeForDoorUpdate.Doors.Add(doorName);
            return true;
        }
      

        public bool RemoveDoorFromBadge(int badgeID, string doorName)
        {
            var deletedDoorFromBadge = GetBadgeByKey(badgeID);
            if (deletedDoorFromBadge != null)
            {
                deletedDoorFromBadge.Doors.Remove(doorName);
                return true;
            }
            return false;
        }


    }
