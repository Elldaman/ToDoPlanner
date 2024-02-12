using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyTask;

namespace ToDoPlanner
{
    public class DataStore : INotifyPropertyChanged
    {
        public ObservableCollection<MyTask.MyTask> mTaskList {get; set;}

        private int _todayPoints;
        public int mTodayPoints
        {
            get { return _todayPoints; }
            set 
            { 
                _todayPoints = value;
                OnPropertyChanged();
            }
        }

        private int _totalPoints;
        public int mTotalPoints
        {
            get { return _totalPoints; }
            set 
            {
                _totalPoints = value;
                OnPropertyChanged();
            }
        }

        public DataStore()
        {
            mTaskList = new ObservableCollection<MyTask.MyTask>();
            TrackTask("Wash the car", 100);
            TrackTask("Code project", 200);
            TrackTask("Make a meal", 300);
            Task.Run(() =>
            {
                while (true)
                {
                    Debug.WriteLine($"Points: {mTodayPoints}");
                    Thread.Sleep(500);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void TrackTask(string taskName, int taskPoints)
        {
            MyTask.MyTask task = new MyTask.MyTask(taskName, taskPoints);
            mTaskList.Add(task);
        }

        public void EditTask(string taskName, int taskPoints, MyTask.MyTask task)
        {
            for(int taskIndex = 0; taskIndex < mTaskList.Count; taskIndex++)
            {
                if (mTaskList[taskIndex] == task)
                {
                    mTaskList[taskIndex] = new MyTask.MyTask(taskName, taskPoints);
                    break;
                }
            }
        }

        public void CompleteTask(MyTask.MyTask task)
        {
            if (!task.Completed)
            {
                task.Completed = true;
                mTodayPoints += task.Points;
                mTotalPoints += task.Points;
            }
        }
    }
}
