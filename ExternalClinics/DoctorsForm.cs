using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExternalClinics
{
    public partial class DoctorsForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DoctorsForm()
        {
            InitializeComponent();

            string strsql = "select Doc_Code as [Dr Code], Doc_Name as [Dr Name], Spec_Desc as [Dr Specialty] ";
            strsql += "from tbl_Doctors ";
            strsql += "inner join tbl_Specialties on tbl_Doctors.Doc_Specialty = tbl_Specialties.Spec_Code ";
            strsql += "where Doc_Status = 'A'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(strsql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dataGridView1.DataSource = dt;
                                dataGridView1.Dock = DockStyle.Fill;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void AddNew_Func()
        {
            DoctorsAdd frm = new DoctorsAdd();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Add";

            if (Functions.CheckOpened("DoctorsAdd"))
            {
                frm.Focus();
            }
            else
            {
                frm.Show();
            }
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            AddNew_Func();
        }
    }
}
