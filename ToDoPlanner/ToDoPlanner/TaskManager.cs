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
            TaskMaintenance();
            if (saveManager.LastUsedDate != DateOnly.FromDateTime(DateTime.Now))
                data.TodayPoints = 0;
            saveDataLoaded = true;
        }

        static private void TaskMaintenance()
        {
            for(int taskIndex = 0; taskIndex < mData.TaskList.Count; taskIndex++)
            {
                ResetDailyCompletion(mData.TaskList[taskIndex]);
                if (RemoveCompletedLongTerm(mData.TaskList[taskIndex]))
                    taskIndex--;
            }
            SyncTaskLists();
        }

        static public void PrepareCompletedTasks()
        {
            saveManager.LoadCompletedTasks();
        }

        static public void AddCompletedTask(MyTask task)
        {
            mData.CompletedTaskList.Add(task);
        }

        static public void TrackTask(string taskName, int taskPoints, TaskType type, bool completed, DateOnly completionDate)
        {
            MyTask task = new MyTask(taskName, taskPoints, type, completed, completionDate);
            mData.TaskList.Add(task);
            SyncTaskLists();
            if(saveDataLoaded)
                saveManager.AddTaskEntry(task, saveManager.TasksFileName);
        }

        static private void SyncTaskLists()
        {
            mData.DailyTaskList.Clear();
            mData.LongTermTaskList.Clear();
            foreach(MyTask task in mData.TaskList)
            {
                if (task.TaskLength == TaskType.Daily)
                    mData.DailyTaskList.Add(task);
                if (task.TaskLength == TaskType.LongTerm)
                    mData.LongTermTaskList.Add(task);
            }
        }

        static public void EditTask(string taskName, int taskPoints, MyTask task)
        {
            task.TaskName = taskName;
            task.Points = taskPoints;
            saveManager.RegenerateData(mData);
        }

        static public void CompleteTask(MyTask task)
        {
            if (task.Completed)
                return;
            task.Completed = true;
            task.CompletionDate = DateOnly.FromDateTime(DateTime.Now);
            mData.TotalPoints += task.Points;
            mData.TodayPoints += task.Points;
            saveManager.AddTaskEntry(task, saveManager.CompletionsFileName);
            saveManager.RegenerateData(mData);
        }

        static public void DeleteTask(MyTask task)
        {
            if (task.TaskLength == TaskType.Daily)
                mData.DailyTaskList.Remove(task);
            else
                mData.LongTermTaskList.Remove(task);
            mData.TaskList.Remove(task);
            saveManager.RegenerateData(mData);
        }

        static private void ResetDailyCompletion(MyTask task)
        {
            if (!task.Completed || task.TaskLength == TaskType.LongTerm)
                return;
            if(task.CompletionDate != DateOnly.FromDateTime(DateTime.Now))
            {
                task.Completed = false;
            }
        }

        static private bool RemoveCompletedLongTerm(MyTask task)
        {
            if(task.Completed && task.TaskLength == TaskType.LongTerm)
            {
                DeleteTask(task);
                return true;
            }
            return false;
        }
    }
}
