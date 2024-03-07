using MyTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.IO.Pipes;

namespace ToDoPlanner
{
    class SaveManager
    {
        private ToDoPlanner.DataStore mData;
        private string _fileName;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _folderPath;

        public string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }


        public SaveManager(DataStore data) 
        {
            mData = data;
            FileName = "tasks.txt";
            FolderPath = Directory.GetCurrentDirectory() + "/../SaveData/";
            if(!File.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (!File.Exists(FolderPath + "tasks.txt"))
            {
                FileStream fs = File.Create(FolderPath + FileName, 1024);
            }
        }

        public void AddEntry(MyTask.MyTask task)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(FolderPath, FileName), true))
            {
                outputFile.WriteLine($"{task.TaskLength}, {task.TaskName}, {task.Points}, {task.Completed}");
            }
        }

        public void RemoveEntry(MyTask.MyTask task) 
        {

        }

        public void LoadData()
        {
            const int BufferSize = 1024;
            using (var fileStream = File.OpenRead(Path.Combine(FolderPath, FileName)))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] taskElements = line.Split(",");
                    MyTask.TaskType taskType;
                    if (taskElements[0] == "Daily")
                        taskType = TaskType.Daily;
                    else if (taskElements[0] == "LongTerm")
                        taskType = TaskType.LongTerm;
                    else
                        throw new ArgumentException("Parameter must be Daily or LongTerm");

                    String taskName = taskElements[1];
                    int points = Int32.Parse(taskElements[2]);

                    TaskManager.TrackTask(taskName, points, taskType, mData);
                }
            }
        }
    }
}
