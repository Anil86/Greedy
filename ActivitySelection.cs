using System.Collections.Generic;
using static System.Console;

namespace Greedy
{
    public class ActivitySelection
    {
        private void SelectMaxActivities()
        {
            _activities.Sort((a1, a2) => a1.End.CompareTo(a2.End));

            MaxActivity(0);



            void MaxActivity(int i)
            {
                if (i == 0)
                {
                    _selectedActivities.Add(_activities[i]);

                    MaxActivity(i + 1);
                }
                else
                {
                    if (i == _activities.Count) return;


                    while (_activities[i].Start < _selectedActivities[_selectedActivities.Count - 1].End)
                    {
                        i++;

                        if (i == _activities.Count) return;
                    }

                    _selectedActivities.Add(_activities[i]);

                    MaxActivity(i + 1);
                }
            }
        }



        internal static void Work()
        {
            var activitySelection = new ActivitySelection();
            activitySelection.SelectMaxActivities();

            foreach (var selectedActivity in activitySelection._selectedActivities) Write(selectedActivity);
        }



        private readonly List<Activity> _activities = new List<Activity>(6)
        {
            new Activity("A1", 0, 6),
            new Activity("A2", 3, 4),
            new Activity("A3", 1, 2),
            new Activity("A4", 5, 8),
            new Activity("A5", 5, 7),
            new Activity("A6", 8, 9)
        };
        private readonly List<Activity> _selectedActivities = new List<Activity>(6);
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