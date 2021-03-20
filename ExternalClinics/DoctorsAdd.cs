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
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public DoctorsAdd()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if(this.Text == "Add Doctor")
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

                    using (SqlConnection con = new SqlConnection(connectionString))
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
