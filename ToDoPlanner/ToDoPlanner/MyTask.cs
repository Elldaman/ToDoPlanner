using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTask
{
    public class MyTask
    {
        public string mTaskName { get; set; }
        public int mPoints {get; set; }

        public bool mCompleted { get; set; }

        public MyTask(string name, int points)
        {
            mTaskName = name;
            mPoints = points;
            mCompleted = false;
        }
    }
}
