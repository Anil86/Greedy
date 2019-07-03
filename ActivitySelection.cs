using System.Collections.Generic;
using static System.Console;

namespace Greedy
{
    public class ActivitySelection
    {
        private IEnumerable<Activity> SelectMaxActivities(List<Activity> activities)
        {
            activities.Sort((a1, a2) => a1.End.CompareTo(a2.End));   // Sort
            

            //var selectedActivities = new List<Activity>(activities.Count);
            //SelectMaxActivitiesUsingList_(0);
            //return selectedActivities;


            Activity previousActivity = default;
            return SelectMaxActivitiesUsingYield_(0);



            //void SelectMaxActivitiesUsingList_(int i)
            //{
            //    if (i >= activities.Count) return;

            //    if (i == 0) selectedActivities.Add(activities[i]);
            //    else
            //        for (; i < activities.Count; i++)
            //        {
            //            if (activities[i].Start < selectedActivities[selectedActivities.Count - 1].End) continue;

            //            selectedActivities.Add(activities[i]);
            //            break;
            //        }


            //    SelectMaxActivitiesUsingList_(i + 1);
            //}



            IEnumerable<Activity> SelectMaxActivitiesUsingYield_(int i)
            {
                if (i >= activities.Count) yield break;

                if (i == 0) yield return previousActivity = activities[i];
                else
                    for (; i < activities.Count; i++)
                    {
                        if (activities[i].Start < previousActivity.End) continue;

                        yield return previousActivity = activities[i];
                        break;
                    }


                // Iterate to get result of recursive call
                var activitiesUsingRecursion = SelectMaxActivitiesUsingYield_(i + 1);
                foreach (var activity in activitiesUsingRecursion)
                    yield return activity;
            }
        }



        internal static void Work()
        {
            var activities = new List<Activity>
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