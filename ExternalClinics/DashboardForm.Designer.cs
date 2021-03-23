
using System.Windows.Forms;
using System.Drawing;

namespace ExternalClinics
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.TopBar = new System.Windows.Forms.Panel();
            this.Rooms = new System.Windows.Forms.Button();
            this.Patients = new System.Windows.Forms.Button();
            this.Doctors = new System.Windows.Forms.Button();
            this.Appointments = new System.Windows.Forms.Button();
            this.TopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.Transparent;
            this.TopBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.TopBar.Controls.Add(this.Rooms);
            this.TopBar.Controls.Add(this.Patients);
            this.TopBar.Controls.Add(this.Doctors);
            this.TopBar.Controls.Add(this.Appointments);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(800, 54);
            this.TopBar.TabIndex = 0;
            // 
            // Rooms
            // 
            this.Rooms.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Rooms.Location = new System.Drawing.Point(266, -2);
            this.Rooms.Name = "Rooms";
            this.Rooms.Size = new System.Drawing.Size(78, 54);
            this.Rooms.TabIndex = 3;
            this.Rooms.Text = "Rooms";
            this.Rooms.UseVisualStyleBackColor = true;
            this.Rooms.Click += new System.EventHandler(this.Rooms_Click);
            // 
            // Patients
            // 
            this.Patients.Location = new System.Drawing.Point(180, 0);
            this.Patients.Name = "Patients";
            this.Patients.Size = new System.Drawing.Size(80, 52);
            this.Patients.TabIndex = 2;
            this.Patients.Text = "Patients";
            this.Patients.UseVisualStyleBackColor = true;
            this.Patients.Click += new System.EventHandler(this.Patients_Click);
            // 
            // Doctors
            // 
            this.Doctors.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Doctors.Location = new System.Drawing.Point(99, 0);
            this.Doctors.Name = "Doctors";
            this.Doctors.Size = new System.Drawing.Size(75, 52);
            this.Doctors.TabIndex = 1;
            this.Doctors.Text = "Doctors";
            this.Doctors.UseVisualStyleBackColor = false;
            this.Doctors.Click += new System.EventHandler(this.Doctors_Click);
            // 
            // Appointments
            // 
            this.Appointments.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Appointments.Location = new System.Drawing.Point(0, 0);
            this.Appointments.Name = "Appointments";
            this.Appointments.Size = new System.Drawing.Size(93, 52);
            this.Appointments.TabIndex = 0;
            this.Appointments.Text = "Appointments";
            this.Appointments.UseVisualStyleBackColor = false;
            this.Appointments.Click += new System.EventHandler(this.Appointments_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 327);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashboardForm_KeyDown);
            this.TopBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel TopBar;
        private Button Appointments;
        private Button Doctors;
        private Button Patients;
        private Button Rooms;
    }
}