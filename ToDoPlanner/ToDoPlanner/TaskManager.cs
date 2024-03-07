using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTask;
using ToDoPlanner;

namespace MyTask
{
    static internal class TaskManager
    {
        public static SaveManager saveManager { get; private set; }
        public static bool saveDataLoaded { get; private set; }

        static public void Initialise(DataStore data)
        {
            saveDataLoaded = false;
            saveManager = new SaveManager(data);
            saveManager.LoadData();
            saveDataLoaded = true;
        }

        static public void TrackTask(string taskName, int taskPoints, TaskType type, DataStore data)
        {
            MyTask task = new MyTask(taskName, taskPoints, type);
            data.TaskList.Add(task);
            if (type == TaskType.Daily)
                data.DailyTaskList.Add(task);
            else
                data.LongTermTaskList.Add(task);
            if(saveDataLoaded)
                saveManager.AddEntry(task);
        }

        static public void EditTask(string taskName, int taskPoints, MyTask task)
        {
            task.TaskName = taskName;
            task.Points = taskPoints;
        }

        static public void CompleteTask(MyTask task, DataStore data)
        {
            if (task.Completed)
                return;
            task.Completed = true;
            data.TotalPoints += task.Points;
            data.TodayPoints += task.Points;
        }

        static public void DeleteTask(MyTask task, DataStore data)
        {
            if (task.TaskLength == TaskType.Daily)
                data.DailyTaskList.Remove(task);
            else
                data.LongTermTaskList.Remove(task);
            data.TaskList.Remove(task);
            saveManager.RemoveEntry(task);
        }
    }
}
