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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoPlanner
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        private Planner _plannerPage;
        private Calendar _calendarPage;
        public Dashboard()
        {
            InitializeComponent();
            _plannerPage = new Planner(this);
            _calendarPage = new Calendar(this);
        }
        
        private void ViewPlanner(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(_plannerPage);
        }

        private void ViewCalendar(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(_calendarPage);
        }
    }
}
