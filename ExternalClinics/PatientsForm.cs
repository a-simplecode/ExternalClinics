using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExternalClinics
{
    public partial class PatientsForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public PatientsForm()
        {
            InitializeComponent();

            string strsql = "select Pat_ID as [ID], Pat_FirstName +' '+ Pat_FamilyName as [Name], ";
            strsql += "Doc_Name as [Doctor],Pat_Telephone as [Phone], Pat_Address as [Address], ";
            strsql += "CASE WHEN Pat_Sex = 'M' THEN 'Male' else 'Female' END AS [Sex], Pat_BloodGroup as [Blood Groop] ";
            strsql += "from tbl_Patients ";
            strsql += "inner join tbl_Doctors on tbl_Patients.Pat_Doctor = Doc_Code ";

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
            PatientsAdd frm = new PatientsAdd();
            frm.MdiParent = this.MdiParent;
            frm.Text = "Add";

            if (Functions.CheckOpened("PatientsAdd"))
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
