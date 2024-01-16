namespace ToDoPlanner
{
    public partial class Dashboard : Form
    {
        List<Panel> listPanel = new List<Panel>();
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            listPanel.Add(PanelDashboard);
            listPanel.Add(PanelPlanning);
            listPanel.Add(PanelCalendar);
            listPanel[1].Visible = false;
            listPanel[2].Visible = false;
            listPanel[0].Visible = true;
            listPanel[0].BringToFront();
        }
        private void ButtonPlanning_Click(object sender, EventArgs e)
        {
            listPanel[0].Visible = false;
            listPanel[1].Visible = true;
            listPanel[1].BringToFront();
        }
        private void ButtonCalendar_Click(object sender, EventArgs e)
        {
            listPanel[2].Visible = true;
            listPanel[0].Visible = false;
            listPanel[2].BringToFront();
        }
        private void ButtonCDashboard_Click(object sender, EventArgs e)
        {
            listPanel[2].Visible = false;
            listPanel[0].Visible = true;
            listPanel[0].BringToFront();
        }
        private void ButtonPDashboard_Click(object sender, EventArgs e)
        {
            listPanel[1].Visible = false;
            listPanel[0].Visible = true;
            listPanel[0].BringToFront();
        }
    }
}
