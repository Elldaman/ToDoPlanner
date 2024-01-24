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
        public ObservableCollection<Task.Task> mTaskList;

        public DataStore()
        {
            mTaskList = new ObservableCollection<Task.Task>();
        }

        public void TrackTask(Task.Task task)
        {
            mTaskList.Add(task);
        }
    }
}
