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
    public partial class RoomsAdd : Form
    {
        public RoomsAdd()
        {
            InitializeComponent();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (this.Text == "Add")
            {
                Room_Code.Text = "";
                Room_Desc.Text = "";
                Room_Status_Active.Checked = true;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            bool error = false;

            if (Room_Code.Text.Trim() == "")
            {
                error = true;
                Room_Code.BackColor = Color.Red;
            }

            if (Room_Desc.Text.Trim() == "")
            {
                error = true;
                Room_Desc.BackColor = Color.Red;
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
                    if (Room_Status_Active.Checked) status = "A";

                    string strsql = "INSERT INTO tbl_Rooms VALUES(";
                    strsql += Room_Code.Text.ToQueryString() + "," + Room_Desc.Text.ToQueryString() + ",'" + status + "','SA',CURRENT_TIMESTAMP)";

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

        private void Room_Code_Leave(object sender, EventArgs e)
        {
            if (Room_Code.Text.Trim() != "")
            {
                try
                {
                    string strsql = "SELECT Room_Code FROM tbl_Rooms where Room_Code = " + Room_Code.Text.ToQueryString();

                    using (SqlConnection con = new SqlConnection(cls_Shared.connectionsString))
                    {
                        using (SqlCommand cmd = new SqlCommand(strsql, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            con.Open();
                            var res = cmd.ExecuteScalar();
                            if (res != null)
                            {
                                MessageBox.Show("Room Code '" + Room_Code.Text + "' Already Exists", "Alert");
                                Room_Code.Text = "";
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
