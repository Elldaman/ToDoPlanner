using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanner
{
    public class CalendarManager
    {
        private DataStore mData;
        public CalendarManager(DataStore data) 
        {
            mData = data;
            DateOnly todaysDate = DateOnly.FromDateTime(DateTime.Now);
            UpdateSelectedDayList(todaysDate);
        }

        public void UpdateSelectedDayList(DateOnly date)
        {
            mData.SelectedDayTaskList.Clear();
            foreach(MyTask.MyTask task in mData.CompletedTaskList) 
            { 
                if(task.CompletionDate == date) 
                {
                    mData.SelectedDayTaskList.Add(task);
                }
            }
        }
    }
}
