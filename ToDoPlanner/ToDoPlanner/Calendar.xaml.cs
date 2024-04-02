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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Page
    {
        private Dashboard _prevPage;
        private ToDoPlanner.DataStore mData;
        private CalendarManager mCalendarManager;
        public Calendar(Dashboard prevPage, DataStore mData, CalendarManager calendarManager)
        {
            InitializeComponent();
            _prevPage = prevPage;
            this.DataContext = _prevPage.DataContext;
            this.mData = mData;
            completedList.ItemsSource = mData.SelectedDayTaskList;
            mCalendarManager = calendarManager;
            dateLongForm.Text = (DateOnly.FromDateTime(DateTime.Now)).ToString();
        }

        private void ViewDashboard(object sender, RoutedEventArgs e)
        {
            calendar.SelectedDate = DateTime.Now;
            this.NavigationService.Navigate(_prevPage);
        }

        private void UpdateSelectedDay(object sender, RoutedEventArgs e) 
        {
            if(calendar.SelectedDate != null) 
            {
                mCalendarManager.UpdateSelectedDayList(DateOnly.FromDateTime((DateTime)calendar.SelectedDate));
                dateLongForm.Text = (DateOnly.FromDateTime((DateTime)calendar.SelectedDate)).ToString();
            }
            Mouse.Capture(null);

        }
    }
}
