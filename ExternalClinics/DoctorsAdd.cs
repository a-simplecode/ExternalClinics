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
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                if (dt.Rows.Count > 0)
                                {
                                    this.Doc_Specialty.DataSource = dt;
                                    this.Doc_Specialty.DisplayMember = "label";
                                    this.Doc_Specialty.ValueMember = "value";
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

            private void Clear_Click(object sender, EventArgs e)
        {
            if(this.Text == "Add")
            {
                Doc_Code.Text = "";
                Doc_Name.Text = "";
                Doc_Specialty.Text = "";
                Doc_Photo.Image = null;
                Doc_Status_Active.Checked = true;
                Doc_Password.Text = "";
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool error = false;

            if(Doc_Code.Text.Trim() == "")
            {
                error = true;
                Doc_Code.BackColor = Color.Red;
            }

            if(Doc_Name.Text.Trim() == "")
            {
                error = true;
                Doc_Name.BackColor = Color.Red;
            }

            if(Doc_Specialty.Text.Trim() == "")
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

                    string strsql = "INSERT INTO tbl_Doctors VALUES(";
                    strsql += Doc_Code.Text.ToQueryString() + "," + Doc_Name.Text.ToQueryString() + "," + Doc_Specialty.Text.ToQueryString() + ",";
                    strsql += "NULL,'" + status +"'," + Doc_Password.Text.ToQueryString() +",'SA',CURRENT_TIMESTAMP)";

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
            if(Doc_Code.Text.Trim() != "")
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
                                MessageBox.Show("Doctor Code '"+ Doc_Code.Text+"' Already Exists","Alert");
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
