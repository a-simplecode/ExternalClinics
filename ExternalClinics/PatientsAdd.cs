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
    public partial class PatientsAdd : Form
    {
        public PatientsAdd()
        {
            InitializeComponent();

            FillDoctors();

            if (PatientsForm.patientObj.Count > 0)
            {
                EditForm();
            }
        }

        private void FillDoctors()
        {
            string strsql = "select Doc_Code as [value], Doc_name as [label] ";
            strsql += "from tbl_Doctors ";
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
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds,"Doctors");
                                if (ds.Tables["Doctors"].Rows.Count > 0)
                                {
                                    this.Pat_Doctor.DataSource = ds.Tables["Doctors"];
                                    this.Pat_Doctor.DisplayMember = "label";
                                    this.Pat_Doctor.ValueMember = "value";
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
            Pat_Doctor.SelectedValue = PatientsForm.patientObj["Pat_Doctor"].ToString();
            Pat_FamilyName.Text = PatientsForm.patientObj["Pat_FamilyName"].ToString();
            Pat_FirstName.Text = PatientsForm.patientObj["Pat_FirstName"].ToString();
            Pat_FatherName.Text = PatientsForm.patientObj["Pat_FatherName"].ToString();
            Pat_Address.Text = PatientsForm.patientObj["Pat_Address"].ToString();
            Pat_Telephone.Text = PatientsForm.patientObj["Pat_Telephone"].ToString();
            Pat_Fax.Text = PatientsForm.patientObj["Pat_Fax"].ToString();
            Pat_Email.Text = PatientsForm.patientObj["Pat_Email"].ToString();
            Pat_Photo.Image = null;
            Pat_BloodGroup.Text = PatientsForm.patientObj["Pat_BloodGroup"].ToString();
            Pat_BirthDate.Text = PatientsForm.patientObj["Pat_BirthDate"].ToString();
            Pat_Sex_Male.Checked = PatientsForm.patientObj["Pat_Sex"].ToString() == "Male" ? true : false;
            Pat_Sex_Female.Checked = PatientsForm.patientObj["Pat_Sex"].ToString() == "Female" ? true : false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (this.Text == "Add")
            {
                Pat_Doctor.Text = "";
                Pat_FamilyName.Text = "";
                Pat_FirstName.Text = "";
                Pat_FatherName.Text = "";
                Pat_Address.Text = "";
                Pat_Telephone.Text = "";
                Pat_Fax.Text = "";
                Pat_Email.Text = "";
                Pat_Photo.Image = null;
                Pat_BloodGroup.Text = "";
                Pat_BirthDate.Text = "";
                Pat_Sex_Male.Checked = true;
            }
            else
            {
                EditForm();
            }
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
            bool error = false;

            if (Pat_FamilyName.Text.Trim() == "")
            {
                error = true;
                Pat_FamilyName.BackColor = Color.Red;
            }

            if (Pat_FirstName.Text.Trim() == "")
            {
                error = true;
                Pat_FirstName.BackColor = Color.Red;
            }

            if (Pat_FatherName.Text.Trim() == "")
            {
                error = true;
                Pat_FatherName.BackColor = Color.Red;
            }

            if (Pat_Telephone.Text.Trim() == "")
            {
                error = true;
                Pat_Telephone.BackColor = Color.Red;
            }

            if (Pat_BloodGroup.Text.Trim() == "")
            {
                error = true;
                Pat_BloodGroup.BackColor = Color.Red;
            }

            if (Pat_BirthDate.Text.Trim() == "")
            {
                error = true;
                Pat_BirthDate.BackColor = Color.Red;
            }

            if (error)
            {
                MessageBox.Show("Some Required Fields Can't Be Left Empty.", "Alert");
            }
            else
            {
                string strsql = "DECLARE @lastID as numeric(18,0) = (select isnull(MAX(Pat_ID),0)+1 as [Pat_ID] from tbl_Patients); ";
                try
                {
                    string sex = "I";
                    if (Pat_Sex_Male.Checked) sex = "M";


                    strsql += "IF NOT EXISTS(SELECT Pat_ID from tbl_Patients where Pat_ID = " + PatientsForm.patientObj["Pat_ID"] + ") ";
                    strsql += "insert into tbl_Patients values (@lastID," + Pat_Doctor.SelectedValue.ToString().ToQueryString() + ", @lastID," + Pat_FamilyName.Text.ToQueryString();
                    strsql += ", " + Pat_FirstName.Text.ToQueryString() + ", " + Pat_FatherName.Text.ToQueryString() + ", " + Pat_Address.Text.ToQueryString();
                    strsql += ", " + Pat_Telephone.Text.ToQueryString() + ", " + Pat_Fax.Text.ToQueryString() + ", " + Pat_Email.Text.ToQueryString();
                    strsql += ", NULL, " + Pat_BloodGroup.Text.ToQueryString() + ", " + Pat_BirthDate.Value.ToString().ToQueryString() + ", '" + sex + "','SA',CURRENT_TIMESTAMP) ";
                    strsql += "ELSE ";
                    strsql += "UPDATE tbl_Patients set Pat_Doctor = " + Pat_Doctor.SelectedValue.ToString().ToQueryString() + ", ";
                    strsql += "Pat_FamilyName = " + Pat_FamilyName.Text.ToQueryString()+ ", ";
                    strsql += "Pat_FirstName = " + Pat_FirstName.Text.ToQueryString() + ", ";
                    strsql += "Pat_FatherName = " + Pat_FatherName.Text.ToQueryString() + ", ";
                    strsql += "Pat_Address = " + Pat_Address.Text.ToQueryString() + ", ";
                    strsql += "Pat_Telephone = " + Pat_Telephone.Text.ToQueryString() + ", ";
                    strsql += "Pat_Fax = " + Pat_Fax.Text.ToQueryString() + ", ";
                    strsql += "Pat_Email = " + Pat_Email.Text.ToQueryString() + ", ";
                    strsql += "Pat_BloodGroup = " + Pat_BloodGroup.Text.ToQueryString() + ", ";
                    strsql += "Pat_BirthDate = " + Pat_BirthDate.Value.ToString().ToQueryString() + ", Pat_Sex = '"+ sex +"' ";
                    strsql += "WHERE Pat_ID = " + PatientsForm.patientObj["Pat_ID"].ToString().ToQueryString();


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
    }
}
