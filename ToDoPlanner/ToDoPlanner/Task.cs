using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class Task
    {
        string mTaskName;
        int mPoints;

        public Task(string name, int points)
        {
            mTaskName = name;
            mPoints = points;
        }
    }
}
