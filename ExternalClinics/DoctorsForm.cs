using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExternalClinics
{
    public partial class DoctorsForm : Form
    {
        
        public DoctorsForm()
        {
            InitializeComponent();

            fillDoc();
        }
        private void fillDoc()
        {
            string strsql = "select Doc_Code, Doc_Name, Spec_Desc ";
            strsql += "from tbl_Doctors ";
            strsql += "inner join tbl_Specialties on tbl_Doctors.Doc_Specialty = tbl_Specialties.Spec_Code ";
            strsql += "where Doc_Status = 'A'";

            try
            {
                using (SqlConnection con = new SqlConnection(cls_Shared.connectionsString))
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
                                dataGridView1.Columns[0].Width = 90;
                                dataGridView1.Columns[0].HeaderText = "";
                                dataGridView1.Columns[1].Width = 200;
                                dataGridView1.Columns[1].HeaderText = "Code";
                                dataGridView1.Columns[2].Width = 400;
                                dataGridView1.Columns[2].HeaderText = "Name";
                                dataGridView1.Columns[3].Width = 200;
                                dataGridView1.Columns[3].HeaderText = "Specialty";
                                //dataGridView1.Columns["Dr Code"].Width = 90;
                                //dataGridView1.Columns["Dr Code"].HeaderText = "My Doc Code";
                                //dataGridView1.Columns[0].Visible

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
            using (DoctorsAdd frm = new DoctorsAdd())
            {
                frm.Owner = this;
                frm.ShowDialog();
                fillDoc();
            }
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            AddNew_Func();
        }
    }
}
