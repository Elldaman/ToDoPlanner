using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoPlanner;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for EditItem.xaml
    /// </summary>
    public partial class EditTask : Window
    {
        private ToDoPlanner.DataStore mData;
        private MyTask.MyTask mSelectedTask;
        private string NameData
        {
            get { return nameField.Text; }
        }
        private int PointsData
        {
            get { return Int32.Parse(pointsField.Text); }
        }

        public EditTask(ToDoPlanner.DataStore data, MyTask.MyTask selectedTask)
        {
            InitializeComponent();
            mData = data;
            mSelectedTask = selectedTask;
            nameField.Text = mSelectedTask.mTaskName;
            pointsField.Text = (mSelectedTask.mPoints).ToString();
        }

        public void EditTaskInfo(object sender, RoutedEventArgs e)
        {
            string taskName = NameData;
            int taskPoints = PointsData;
            Debug.WriteLine("Calling data function");
            mData.EditTask(taskName, taskPoints, mSelectedTask);
            this.Close();
        }
    }
}
