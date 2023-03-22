using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class GroupSchedule
    {
        private GroupActivity activity;
        private List<GroupActivity> activities;

        public GroupSchedule(GroupActivity activity)
        {
            activities = new List<GroupActivity>();
            activities.Add(activity);
        }

        public void ViewSchedule()
        {
                Console.WriteLine($"Group Schedule:");
                foreach (GroupActivity activity in activities)
                {
                Console.WriteLine("===========================================");
                Console.WriteLine(activity + "\n");
                }
        }
        public void AddActivity(GroupActivity activity)
        {
                activities.Add(activity);
        }
        public void RemoveActivity(User user, GroupActivity activityID)
        {
                activities.Remove(activityID);
        }
        public void UpdateActivity(User user, GroupActivity activityID, GroupActivity activity)
        {
            if (user.GetType() == typeof(Customer))
            {
                Console.WriteLine("You are not allowed to update activities");
            }
            else
            {
                //ToDO
            }
        }
    }
}

