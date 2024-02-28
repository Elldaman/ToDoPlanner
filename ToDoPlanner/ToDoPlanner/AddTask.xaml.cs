using System;
using System.Collections.Generic;
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
using MyTask;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private ToDoPlanner.DataStore mData;
        private string NameData
        {
            get { return nameField.Text; }
        }
        private int PointsData
        {
            get { return Int32.Parse(pointsField.Text); }
        }

        public AddTask(ToDoPlanner.DataStore data)
        {
            InitializeComponent();
            mData = data;
        }

        public void SendTaskInfo(object sender, RoutedEventArgs e)
        {
            string taskName = NameData;
            int taskPoints = PointsData;
            TaskType type;
            ComboBoxItem selectedType = (ComboBoxItem)typeField.SelectedItem;
            string typeString = (selectedType.Content).ToString();
            if (typeString == "Daily")
                type = TaskType.Daily;
            else
                type = TaskType.LongTerm;
            MyTask.TaskManager.TrackTask(taskName, taskPoints, type, mData);
            this.Close();
        }
    }
}
