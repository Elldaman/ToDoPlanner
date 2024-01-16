namespace ToDoPlanner
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dashTitle = new Label();
            ButtonPlanning = new Button();
            ButtonCalendar = new Button();
            PanelPlanning = new Panel();
            label2 = new Label();
            ButtonPDashboard = new Button();
            PanelCalendar = new Panel();
            PanelDashboard = new Panel();
            ButtonCDashboard = new Button();
            TitleCalendar = new Label();
            PanelPlanning.SuspendLayout();
            PanelCalendar.SuspendLayout();
            PanelDashboard.SuspendLayout();
            SuspendLayout();
            // 
            // dashTitle
            // 
            dashTitle.AutoSize = true;
            dashTitle.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            dashTitle.Location = new Point(284, 23);
            dashTitle.Name = "dashTitle";
            dashTitle.Size = new Size(147, 37);
            dashTitle.TabIndex = 0;
            dashTitle.Text = "Dashboard";
            // 
            // ButtonPlanning
            // 
            ButtonPlanning.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPlanning.Location = new Point(451, 23);
            ButtonPlanning.Name = "ButtonPlanning";
            ButtonPlanning.Size = new Size(98, 37);
            ButtonPlanning.TabIndex = 1;
            ButtonPlanning.Text = "Planning";
            ButtonPlanning.UseVisualStyleBackColor = true;
            ButtonPlanning.Click += ButtonPlanning_Click;
            // 
            // ButtonCalendar
            // 
            ButtonCalendar.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonCalendar.Location = new Point(575, 23);
            ButtonCalendar.Name = "ButtonCalendar";
            ButtonCalendar.Size = new Size(121, 37);
            ButtonCalendar.TabIndex = 2;
            ButtonCalendar.Text = "Calendar";
            ButtonCalendar.UseVisualStyleBackColor = true;
            ButtonCalendar.Click += ButtonCalendar_Click;
            // 
            // PanelPlanning
            // 
            PanelPlanning.Controls.Add(label2);
            PanelPlanning.Controls.Add(ButtonPDashboard);
            PanelPlanning.Location = new Point(30, 29);
            PanelPlanning.Name = "PanelPlanning";
            PanelPlanning.Size = new Size(776, 101);
            PanelPlanning.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(298, 18);
            label2.Name = "label2";
            label2.Size = new Size(121, 37);
            label2.TabIndex = 6;
            label2.Text = "Planning";
            // 
            // ButtonPDashboard
            // 
            ButtonPDashboard.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonPDashboard.Location = new Point(436, 18);
            ButtonPDashboard.Name = "ButtonPDashboard";
            ButtonPDashboard.Size = new Size(113, 37);
            ButtonPDashboard.TabIndex = 1;
            ButtonPDashboard.Text = "Dashboard";
            ButtonPDashboard.UseVisualStyleBackColor = true;
            ButtonPDashboard.Click += ButtonPDashboard_Click;
            // 
            // PanelCalendar
            // 
            PanelCalendar.Controls.Add(ButtonCDashboard);
            PanelCalendar.Controls.Add(TitleCalendar);
            PanelCalendar.Location = new Point(33, 26);
            PanelCalendar.Name = "PanelCalendar";
            PanelCalendar.Size = new Size(776, 101);
            PanelCalendar.TabIndex = 4;
            // 
            // PanelDashboard
            // 
            PanelDashboard.Controls.Add(dashTitle);
            PanelDashboard.Controls.Add(ButtonPlanning);
            PanelDashboard.Controls.Add(ButtonCalendar);
            PanelDashboard.Location = new Point(36, 23);
            PanelDashboard.Name = "PanelDashboard";
            PanelDashboard.Size = new Size(776, 97);
            PanelDashboard.TabIndex = 2;
            // 
            // ButtonCDashboard
            // 
            ButtonCDashboard.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonCDashboard.Location = new Point(436, 19);
            ButtonCDashboard.Name = "ButtonCDashboard";
            ButtonCDashboard.Size = new Size(113, 37);
            ButtonCDashboard.TabIndex = 3;
            ButtonCDashboard.Text = "Dashboard";
            ButtonCDashboard.UseVisualStyleBackColor = true;
            ButtonCDashboard.Click += ButtonCDashboard_Click;
            // 
            // TitleCalendar
            // 
            TitleCalendar.AutoSize = true;
            TitleCalendar.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            TitleCalendar.Location = new Point(298, 19);
            TitleCalendar.Name = "TitleCalendar";
            TitleCalendar.Size = new Size(123, 37);
            TitleCalendar.TabIndex = 2;
            TitleCalendar.Text = "Calendar";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(824, 582);
            Controls.Add(PanelDashboard);
            Controls.Add(PanelCalendar);
            Controls.Add(PanelPlanning);
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            PanelPlanning.ResumeLayout(false);
            PanelPlanning.PerformLayout();
            PanelCalendar.ResumeLayout(false);
            PanelCalendar.PerformLayout();
            PanelDashboard.ResumeLayout(false);
            PanelDashboard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label dashTitle;
        private Button ButtonPlanning;
        private Button ButtonCalendar;
        private Panel PanelPlanning;
        private Button ButtonPDashboard;
        private Panel PanelCalendar;
        private Button ButtonCDashboard;
        private Label TitleCalendar;
        private Panel PanelDashboard;
        private Label label2;
    }
}
