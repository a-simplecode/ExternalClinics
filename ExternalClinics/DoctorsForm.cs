using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }
    }
}
