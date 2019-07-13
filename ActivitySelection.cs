using System;
using System.Collections.Generic;
using static System.Console;

namespace Greedy
{
    public class ActivitySelection
    {
        /// <summary>Selects maximum no.of activities.</summary>
        /// <param name="activities">Activities array.</param>
        /// <returns>Selected activities.</returns>
        private IEnumerable<Activity> SelectMaxActivities(Activity[] activities)
        {
            Array.Sort(activities, (a1, a2) => a1.End.CompareTo(a2.End));   // Sort based on end time


            Activity previousActivity = default;   // Store previous activity for comparison
            return SelectMaxActivities(0);



            IEnumerable<Activity> SelectMaxActivities(int i)
            {
                if (i >= activities.Length) yield break;   // Stop when checked all activities

                if (i == 0) yield return previousActivity = activities[i];   // Select 1st activity
                else
                    for (; i < activities.Length; i++)   // Find next activity w/ start time ≥ previous activity's end time
                    {
                        if (activities[i].Start < previousActivity.End) continue;

                        yield return previousActivity = activities[i];
                        break;
                    }


                foreach (var activity in SelectMaxActivities(i + 1))   // Find next activity
                    yield return activity;
            }
        }



        internal static void Work()
        {
            Activity[] activities =
            {
                new Activity("A1", 1, 2),
                new Activity("A2", 3, 4),
                new Activity("A3", 0, 6),
                new Activity("A4", 5, 7),
                new Activity("A5", 8, 9),
                new Activity("A6", 5, 9)
                
                
                //new Activity("A1", 0, 6),
                //new Activity("A2", 3, 4),
                //new Activity("A3", 1, 2),
                //new Activity("A4", 5, 8),
                //new Activity("A5", 5, 7),
                //new Activity("A6", 8, 9)
            };

            var selectedActivities = new ActivitySelection().SelectMaxActivities(activities);

            foreach (var selectedActivity in selectedActivities) Write(selectedActivity);
        }
    }



    internal struct Activity
    {
        public Activity(string name, int start, int end)
        {
            Name = name;
            Start = start;
            End = end;
        }

        public string Name { get; }
        public int Start { get; }
        public int End { get; }


        /// <inheritdoc />
        public override string ToString() => $"{Name}: ({Start}, {End})\t";
    }
}