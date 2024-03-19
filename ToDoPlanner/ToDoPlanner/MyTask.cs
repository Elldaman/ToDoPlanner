using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    public enum TaskType
    {
        Daily,
        LongTerm
    }
    public class MyTask : INotifyPropertyChanged
    {
        private string _taskName;

        public string TaskName
        {
            get { return _taskName; }
            set 
            { 
                _taskName = value;
                OnPropertyChanged();
            }
        }

        private TaskType _taskLength;

        public TaskType TaskLength
        {
            get { return _taskLength; }
            set
            {
                _taskLength = value;
                OnPropertyChanged();
            }
        }

        private int _points;
        public int Points
        {
            get { return _points; }
            set
            {
                _points = value;
                OnPropertyChanged();
            }
        }

        private bool _completed;
        public bool Completed
        {
            get { return _completed; }
            set
            {
                _completed = value;
                OnPropertyChanged();
            }
        }

        private DateOnly _completionDate;
        public DateOnly CompletionDate
        {
            get { return _completionDate; }
            set
            {
                _completionDate = value;
                OnPropertyChanged();
            }
        }

        public MyTask(string name, int points, TaskType type, bool completed, DateOnly completionDate)
        {
            TaskName = name;
            Points = points;
            TaskLength = type;
            Completed = completed;
            CompletionDate = completionDate;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
