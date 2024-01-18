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
    /// Interaction logic for Planner.xaml
    /// </summary>
    public partial class Planner : Page
    {
        private Dashboard _prevPage;
        public Planner(Dashboard prevPage)
        {
            InitializeComponent();
            _prevPage = prevPage;
        }

        private void ViewDashboard(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(_prevPage);
        }
    }
}
