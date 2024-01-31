using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace DataStore
{
    public class DataStore
    {
        public ObservableCollection<Task.Task> mTaskList {get; set;}

        public DataStore()
        {
            mTaskList = new ObservableCollection<Task.Task>();
            TrackTask("Wash the car", 100);
            TrackTask("Code project", 200);
            TrackTask("Make a meal", 300);
        }

        public void TrackTask(string taskName, int taskPoints)
        {
            Task.Task task = new Task.Task(taskName, taskPoints);
            mTaskList.Add(task);
        }

        public void EditTask(string taskName, int taskPoints, Task.Task task)
        {
            for(int taskIndex = 0; taskIndex < mTaskList.Count; taskIndex++)
            {
                if (mTaskList[taskIndex] == task)
                {
                    mTaskList[taskIndex] = new Task.Task(taskName, taskPoints);
                    break;
                }
            }
        }
    }
}
