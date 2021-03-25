using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ExternalClinics
{
    public partial class PatientsForm : Form
    {
        public static Dictionary<string, object> patientObj = new Dictionary<string, object>();

        public PatientsForm()
        {
            InitializeComponent();
            fillPatients();
        }

        private void fillPatients()
        {
            string strsql = "select Pat_ID,Pat_MedicalFile, Pat_FirstName, Pat_FatherName, Pat_FamilyName,Doc_Code, ";
            strsql += "Doc_Name, Pat_Address, Pat_Telephone, Pat_Fax, Pat_Email, Pat_Photo, Pat_BirthDate, ";
            strsql += "CASE WHEN Pat_Sex = 'M' THEN 'Male' else 'Female' END AS [Pat_Sex], Pat_BloodGroup ";
            strsql += "from tbl_Patients ";
            strsql += "inner join tbl_Doctors on tbl_Patients.Pat_Doctor = Doc_Code ";

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
                                    dataGridView1.Columns[1].Visible = false;//Pat_ID
                                    dataGridView1.Columns[2].HeaderText = "Medical File";
                                    dataGridView1.Columns[2].Width = 100;
                                    dataGridView1.Columns[3].HeaderText = "First Name";
                                    dataGridView1.Columns[3].Width = 150;
                                    dataGridView1.Columns[4].HeaderText = "Father Name";
                                    dataGridView1.Columns[4].Width = 150;
                                    dataGridView1.Columns[5].HeaderText = "Family Name";
                                    dataGridView1.Columns[5].Width = 150;
                                    dataGridView1.Columns[6].Visible = false;//Doc_Code
                                    dataGridView1.Columns[7].HeaderText = "Doctor";
                                    dataGridView1.Columns[7].Width = 150;
                                    dataGridView1.Columns[8].Visible = false;//Address
                                    dataGridView1.Columns[9].HeaderText = "Telephone";
                                    dataGridView1.Columns[9].Width = 100;
                                    dataGridView1.Columns[10].Visible = false;//Fax
                                    dataGridView1.Columns[11].Visible = false;//Email
                                    dataGridView1.Columns[12].Visible = false;//Photo
                                    dataGridView1.Columns[13].HeaderText = "Date Of Birth";
                                    dataGridView1.Columns[13].Width = 100;
                                    dataGridView1.Columns[14].HeaderText = "Sex";
                                    dataGridView1.Columns[14].Width = 100;
                                    dataGridView1.Columns[15].HeaderText = "Blood Group";
                                    dataGridView1.Columns[15].Width = 100;
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
            using (PatientsAdd frm = new PatientsAdd())
            {
                frm.Owner = this;
                frm.ShowDialog();
                fillPatients();
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

                patientObj.Add("Pat_ID", row.Cells["Pat_ID"].Value);
                patientObj.Add("Pat_MedicalFile", row.Cells["Pat_MedicalFile"].Value);
                patientObj.Add("Pat_FirstName", row.Cells["Pat_FirstName"].Value);
                patientObj.Add("Pat_FatherName", row.Cells["Pat_FatherName"].Value);
                patientObj.Add("Pat_FamilyName", row.Cells["Pat_FamilyName"].Value);
                patientObj.Add("Pat_Doctor", row.Cells["Doc_Code"].Value);
                patientObj.Add("Pat_Address", row.Cells["Pat_Address"].Value);
                patientObj.Add("Pat_Telephone", row.Cells["Pat_Telephone"].Value);
                patientObj.Add("Pat_Fax", row.Cells["Pat_Fax"].Value);
                patientObj.Add("Pat_Email", row.Cells["Pat_Email"].Value);
                patientObj.Add("Pat_BirthDate", row.Cells["Pat_BirthDate"].Value);
                patientObj.Add("Pat_Sex", row.Cells["Pat_Sex"].Value);
                patientObj.Add("Pat_BloodGroup", row.Cells["Pat_BloodGroup"].Value);

                using (PatientsAdd frm = new PatientsAdd())
                {
                    frm.Text = "Edit";
                    frm.Owner = this;
                    frm.ShowDialog();
                    fillPatients();
                    patientObj.Clear();
                }
            }
        }
    }
}
