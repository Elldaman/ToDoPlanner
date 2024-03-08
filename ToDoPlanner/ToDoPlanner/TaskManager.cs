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
        public static DataStore mData {  get; private set; }

        static public void Initialise(DataStore data)
        {
            mData = data;
            saveDataLoaded = false;
            saveManager = new SaveManager(mData);
            saveManager.LoadData();
            saveDataLoaded = true;
        }

        static public void TrackTask(string taskName, int taskPoints, TaskType type, bool completed)
        {
            MyTask task = new MyTask(taskName, taskPoints, type, completed);
            mData.TaskList.Add(task);
            if (type == TaskType.Daily)
                mData.DailyTaskList.Add(task);
            else
                mData.LongTermTaskList.Add(task);
            if(saveDataLoaded)
                saveManager.AddEntry(task);
        }

        static public void EditTask(string taskName, int taskPoints, MyTask task)
        {
            task.TaskName = taskName;
            task.Points = taskPoints;
            saveManager.RegenerateListFromData(mData);
        }

        static public void CompleteTask(MyTask task)
        {
            if (task.Completed)
                return;
            task.Completed = true;
            mData.TotalPoints += task.Points;
            mData.TodayPoints += task.Points;
            saveManager.RegenerateListFromData(mData);
        }

        static public void DeleteTask(MyTask task)
        {
            if (task.TaskLength == TaskType.Daily)
                mData.DailyTaskList.Remove(task);
            else
                mData.LongTermTaskList.Remove(task);
            mData.TaskList.Remove(task);
            saveManager.RegenerateListFromData(mData);
        }
    }
}
