using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExternalClinics
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }


        private void Appointments_Click(object sender, EventArgs e)
        {
            Appointments_Load();
        }

        private void Doctors_Click(object sender, EventArgs e)
        {
            Doctors_Load();
        }

        private void Patients_Click(object sender, EventArgs e)
        {
            Patiens_Load();
        }

        private void Rooms_Click(object sender, EventArgs e)
        {
            Rooms_Load();
        }

        private void DashboardForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Appointments_Load();
            }
            else if(e.KeyCode == Keys.F2)
            {
                Doctors_Load();
            }
            else if(e.KeyCode == Keys.F3)
            {
                Patiens_Load();
            }
            else if(e.KeyCode == Keys.F4)
            {
                Rooms_Load();
            }
        }

        private void Appointments_Load()
        {
            AppointmentsForm frm = new AppointmentsForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;

            if (CheckOpened("AppointmentsForm"))
            {
                frm.Focus(); 
            }
            else
            {
                frm.Show();
            }
        }

        private void Doctors_Load()
        {
            DoctorsForm frm = new DoctorsForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;

            if (CheckOpened("DoctorsForm"))
            {
                frm.Focus();
            }
            else
            {
                frm.Show();
            }
        }

        private void Patiens_Load()
        {
            PatientsForm frm = new PatientsForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;

            if (CheckOpened("PatientsForm"))
            {
                frm.Focus();
            }
            else
            {
                frm.Show();
            }
        }

        private void Rooms_Load()
        {
            RoomsForm frm = new RoomsForm();
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;

            if (CheckOpened("RoomsForm"))
            {
                frm.Focus();
            }
            else
            {
                frm.Show();
            }
        }
        private bool CheckOpened(string name)
        {
            FormCollection fc = Application.OpenForms;

            foreach (Form frm in fc)
            {
                if (frm.Text == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
