using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            Task.Task task1 = new Task.Task("Wash the car", 100);
            Task.Task task2 = new Task.Task("Code project", 200);
            Task.Task task3 = new Task.Task("Make a meal", 300);
            TrackTask(task1);
            TrackTask(task2);
            TrackTask(task3);
        }

        public void TrackTask(Task.Task task)
        {
            mTaskList.Add(task);
        }
    }
}
