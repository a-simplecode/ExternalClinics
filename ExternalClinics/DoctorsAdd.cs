using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExternalClinics
{
    public partial class DoctorsAdd : Form
    {

        public DoctorsAdd()
        {
            InitializeComponent();

            FillSpecialty();

            if (DoctorsForm.doctorObj.Count > 0)
            {
                EditForm();
            }
        }

        private void FillSpecialty()
        {
            string strsql = "select Spec_Code as [value], Spec_Desc as [label] ";
            strsql += "from tbl_Specialties ";
            strsql += "where Spec_Status = 'A'";

            try
            {
                using (SqlConnection con = new SqlConnection(cls_Shared.connectionsString))
                {
                    using (SqlCommand cmd = new SqlCommand(strsql, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds, "Specialty");
                                if (ds.Tables["Specialty"].Rows.Count > 0)
                                {
                                    Doc_Specialty.DataSource = ds.Tables["Specialty"];
                                    Doc_Specialty.DisplayMember = "label";
                                    Doc_Specialty.ValueMember = "value";
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
        private void EditForm()
        {
            Doc_Code.Text = DoctorsForm.doctorObj["Doc_Code"].ToString();
            Doc_Code.ReadOnly = true;
            Doc_Code.BackColor = Color.LightGray;
            Doc_Name.Text = DoctorsForm.doctorObj["Doc_Name"].ToString();
            Doc_Specialty.SelectedValue = DoctorsForm.doctorObj["Doc_Specialty"].ToString();
            Doc_Status_Active.Checked = DoctorsForm.doctorObj["Doc_Status"].ToString() == "Active" ? true : false;
            Doc_Status_Inactive.Checked = DoctorsForm.doctorObj["Doc_Status"].ToString() == "Inactive" ? true : false;
            Doc_Password.Text = DoctorsForm.doctorObj["Doc_Password"].ToString();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (this.Text == "Add")
            {
                Doc_Code.Text = "";
                Doc_Name.Text = "";
                Doc_Specialty.Text = "";
                Doc_Photo.Image = null;
                Doc_Status_Active.Checked = true;
                Doc_Password.Text = "";
            }
            else
            {
                EditForm();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (Doc_Code.Text.Trim() == "")
            {
                error = true;
                Doc_Code.BackColor = Color.Red;
            }

            if (Doc_Name.Text.Trim() == "")
            {
                error = true;
                Doc_Name.BackColor = Color.Red;
            }

            if (Doc_Specialty.SelectedValue.ToString() == "")
            {
                error = true;
                Doc_Specialty.BackColor = Color.Red;
            }

            if (Doc_Password.Text.Trim() == "")
            {
                error = true;
                Doc_Password.BackColor = Color.Red;
            }

            if (error)
            {
                MessageBox.Show("Some Required Fields Can't Be Left Empty.", "Alert");
            }
            else
            {

                try
                {
                    string status = "I";
                    if (Doc_Status_Active.Checked) status = "A";

                    string strsql = "IF NOT EXISTS(SELECT Doc_Code from tbl_Doctors where Doc_Code = " + Doc_Code.Text.ToQueryString() + ") ";
                    strsql += "INSERT INTO tbl_Doctors VALUES(";
                    strsql += Doc_Code.Text.ToQueryString() + "," + Doc_Name.Text.ToQueryString() + "," + Doc_Specialty.SelectedValue.ToString().ToQueryString() + ",";
                    strsql += "NULL,'" + status + "'," + Doc_Password.Text.ToQueryString() + ",'SA',CURRENT_TIMESTAMP) ";
                    strsql += "ELSE ";
                    strsql += "UPDATE tbl_Doctors set Doc_Name = " + Doc_Name.Text.ToQueryString() + ", ";
                    strsql += "Doc_Specialty = " + Doc_Specialty.SelectedValue.ToString().ToQueryString() + ", Doc_Status = '" + status + "', ";
                    strsql += "Doc_Password = " + Doc_Password.Text.ToQueryString() + " WHERE Doc_Code = " + Doc_Code.Text.ToQueryString();

                    using (SqlConnection con = new SqlConnection(cls_Shared.connectionsString))
                    {
                        using (SqlCommand cmd = new SqlCommand(strsql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }

                    this.Close();
                    MessageBox.Show("Saved Successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Doc_Code_Leave(object sender, EventArgs e)
        {
            if (Doc_Code.Text.Trim() != "" && this.Text == "Add")
            {
                try
                {
                    string strsql = "SELECT Doc_Code FROM tbl_Doctors where Doc_Code = " + Doc_Code.Text.ToQueryString();

                    using (SqlConnection con = new SqlConnection(cls_Shared.connectionsString))
                    {
                        using (SqlCommand cmd = new SqlCommand(strsql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            var res = cmd.ExecuteScalar();
                            if (res != null)
                            {
                                MessageBox.Show("Doctor Code '" + Doc_Code.Text + "' Already Exists", "Alert");
                                Doc_Code.Text = "";
                            }
                            con.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
