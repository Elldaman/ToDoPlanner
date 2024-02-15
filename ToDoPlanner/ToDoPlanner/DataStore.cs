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
        public ObservableCollection<MyTask.MyTask> TaskList {get; set;}

        private int _todayPoints;
        public int TodayPoints
        {
            get { return _todayPoints; }
            set 
            { 
                _todayPoints = value;
                OnPropertyChanged();
            }
        }

        private int _totalPoints;
        public int TotalPoints
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
            TaskList = new ObservableCollection<MyTask.MyTask>();
            Task.Run(() =>
            {
                while (true)
                {
                    Debug.WriteLine($"Points: {TodayPoints}");
                    Thread.Sleep(500);
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
