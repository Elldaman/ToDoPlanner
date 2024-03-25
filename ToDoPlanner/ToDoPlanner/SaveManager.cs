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

        public string TasksFileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private string _pointsfileName;

        public string PointsFileName
        {
            get { return _pointsfileName; }
            set { _pointsfileName = value; }
        }

        private string _completionsFileName;

        public string CompletionsFileName
        {
            get { return _completionsFileName; }
            set { _completionsFileName = value; }
        }

        private string _folderPath;

        public string FolderPath
        {
            get { return _folderPath; }
            set { _folderPath = value; }
        }

        private DateOnly _lastUsedDate;

        public DateOnly LastUsedDate
        {
            get { return _lastUsedDate; }
            set { _lastUsedDate = value; }
        }


        public SaveManager(DataStore data) 
        {
            mData = data;
            TasksFileName = "tasks.txt";
            PointsFileName = "points.txt";
            CompletionsFileName = "completions.txt";
            FolderPath = Directory.GetCurrentDirectory() + "/../SaveData/";
            if(!File.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            if (!File.Exists(FolderPath + TasksFileName))
            {
                FileStream fs = File.Create(FolderPath + TasksFileName, 1024);
                fs.Close();
            }
            if (!File.Exists(FolderPath + PointsFileName))
            {
                FileStream fs = File.Create(FolderPath + PointsFileName, 1024);
                fs.Close();
            }
            if (!File.Exists(FolderPath + CompletionsFileName))
            {
                FileStream fs = File.Create(FolderPath + CompletionsFileName, 1024);
                fs.Close();
            }
        }

        public void AddTaskEntry(MyTask.MyTask task, String FileName)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(FolderPath, FileName), true))
            {
                outputFile.WriteLine($"{task.TaskLength},{task.TaskName},{task.Points},{task.Completed},{task.CompletionDate}");
            }
        }

        public void UpdatePoints()
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(FolderPath, PointsFileName), true))
            {
                outputFile.WriteLine($"{mData.TotalPoints},{mData.TodayPoints},{DateOnly.FromDateTime(DateTime.Now)}");
            }
        }

        public void RegenerateData(DataStore data)
        {
            File.WriteAllText(Path.Combine(FolderPath, TasksFileName), String.Empty);
            File.WriteAllText(Path.Combine(FolderPath, PointsFileName), String.Empty);
            foreach (MyTask.MyTask task in data.TaskList)
            {
                AddTaskEntry(task, TasksFileName);
            }
            UpdatePoints();
        }

        public void LoadCompletedTasks()
        {
            const int BufferSize = 1024;
            mData.CompletedTaskList.Clear();
            using (var fileStream = File.OpenRead(Path.Combine(FolderPath, CompletionsFileName)))
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
                    bool completed;
                    if (taskElements[3] == "True")
                        completed = true;
                    else if (taskElements[3] == "False")
                        completed = false;
                    else
                        throw new ArgumentException("Parameter must be True or False");

                    DateOnly completionDate = DateOnly.Parse(taskElements[4]);

                    MyTask.MyTask completedTask = new MyTask.MyTask(taskName, points, taskType, completed, completionDate);

                    TaskManager.AddCompletedTask(completedTask);
                }
            }
        }

        public void LoadData()
        {
            const int BufferSize = 1024;
            using (var fileStream = File.OpenRead(Path.Combine(FolderPath, TasksFileName)))
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
                    bool completed;
                    if (taskElements[3] == "True")
                        completed = true;
                    else if (taskElements[3] == "False")
                        completed = false;
                    else
                        throw new ArgumentException("Parameter must be True or False");

                    DateOnly completionDate = DateOnly.Parse(taskElements[4]);

                    TaskManager.TrackTask(taskName, points, taskType, completed, completionDate);
                }
            }

            using (var fileStream = File.OpenRead(Path.Combine(FolderPath, PointsFileName)))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String pointsLine = "";
                if((pointsLine = streamReader.ReadLine()) != null)
                {
                    string[] pointsElements = pointsLine.Split(",");
                    mData.TotalPoints = Int32.Parse(pointsElements[0]);
                    mData.TodayPoints = Int32.Parse(pointsElements[1]);
                    LastUsedDate = DateOnly.Parse(pointsElements[2]);
                }
                return;
            }
        }
    }
}
