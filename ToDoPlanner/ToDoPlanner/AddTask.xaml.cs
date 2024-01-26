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
using DataStore;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Window
    {
        private DataStore.DataStore mData;
        private string NameData
        {
            get { return nameField.Text; }
        }
        private int PointsData
        {
            get { return Int32.Parse(pointsField.Text); }
        }

        public AddTask(DataStore.DataStore data)
        {
            InitializeComponent();
            mData = data;
        }

        public void SendTaskInfo(object sender, RoutedEventArgs e)
        {
            string taskName = NameData;
            int taskPoints = PointsData;
            mData.TrackTask(taskName, taskPoints);
            this.Close();
        }
    }
}
