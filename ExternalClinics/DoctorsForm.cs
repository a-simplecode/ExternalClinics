using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ExternalClinics
{
    public partial class DoctorsForm : Form
    {
        public static Dictionary<string, object> doctorObj = new Dictionary<string, object>();

        public DoctorsForm()
        {
            InitializeComponent();     
            fillDoc();
        }
        private void fillDoc()
        {
            string strsql = "select doc_Code, Doc_Name,Spec_Desc, Doc_Specialty,Doc_Photo, ";
            strsql += "CASE WHEN Doc_Status = 'A' THEN 'Active' ELSE 'Inactive' END as [Doc_Status] , Doc_Password ";
            strsql += "from tbl_Doctors ";
            strsql += "inner join tbl_Specialties on tbl_Doctors.Doc_Specialty = tbl_Specialties.Spec_Code ";

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

                                if(dt.Rows.Count > 0)
                                {
                                    dataGridView1.DataSource = dt;
                                    dataGridView1.Dock = DockStyle.Fill;

                                    dataGridView1.Columns[0].HeaderText = "";
                                    dataGridView1.Columns[0].Width = 50;
                                    dataGridView1.Columns[1].HeaderText = "Code";
                                    dataGridView1.Columns[1].Width = 200;
                                    dataGridView1.Columns[2].HeaderText = "Name";
                                    dataGridView1.Columns[2].Width = 400;
                                    dataGridView1.Columns[3].HeaderText = "Specialty";
                                    dataGridView1.Columns[3].Width = 200;
                                    dataGridView1.Columns[4].Visible = false;
                                    dataGridView1.Columns[5].Visible = false;
                                    dataGridView1.Columns[6].Width = 200;
                                    dataGridView1.Columns[6].HeaderText = "Status";
                                    dataGridView1.Columns[7].Visible = false;
                                }
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewRow row = this.dataGridView1.SelectedRows[0];

                doctorObj.Add("Doc_Code", row.Cells["Doc_Code"].Value);
                doctorObj.Add("Doc_Name", row.Cells["Doc_Name"].Value);
                doctorObj.Add("Doc_Specialty", row.Cells["Doc_Specialty"].Value);
                doctorObj.Add("Doc_Photo", row.Cells["Doc_Photo"].Value);
                doctorObj.Add("Doc_Status", row.Cells["Doc_Status"].Value);
                doctorObj.Add("Doc_Password", row.Cells["Doc_Password"].Value);

                using (DoctorsAdd frm = new DoctorsAdd())
                {
                    frm.Text = "Edit";
                    frm.Owner = this;
                    frm.ShowDialog();
                    fillDoc();
                    doctorObj.Clear();
                }
            }
        }
    }
}
