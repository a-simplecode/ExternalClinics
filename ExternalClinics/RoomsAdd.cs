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
            if (RoomsForm.roomObj.Count > 0)
            {
                EditForm();
            }
        }

        private void EditForm()
        {
            Room_Code.Text = RoomsForm.roomObj["Room_Code"].ToString();
            Room_Code.ReadOnly = true;
            Room_Code.BackColor = Color.LightGray;
            Room_Desc.Text = RoomsForm.roomObj["Room_Desc"].ToString();
            Room_Status_Active.Checked = RoomsForm.roomObj["Room_Status"].ToString() == "Active" ? true : false;
            Room_Status_Inactive.Checked = RoomsForm.roomObj["Room_Status"].ToString() == "Inactive" ? true : false;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            if (this.Text == "Add")
            {
                Room_Code.Text = "";
                Room_Desc.Text = "";
                Room_Status_Active.Checked = true;
            }
            else
            {
                EditForm();
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

                    string strsql = "IF NOT EXISTS(SELECT Room_Code from tbl_Rooms where Room_Code = " + Room_Code.Text.ToQueryString() + ") ";
                    strsql += "INSERT INTO tbl_Rooms VALUES(";
                    strsql += Room_Code.Text.ToQueryString() + "," + Room_Desc.Text.ToQueryString() + ",'" + status + "','SA',CURRENT_TIMESTAMP) ";
                    strsql += "ELSE ";
                    strsql += "UPDATE tbl_Rooms set ";
                    strsql += "Room_Desc = " + Room_Desc.Text.ToQueryString() + ", Room_Status = '" + status + "' ";
                    strsql += "WHERE Room_Code = " + Room_Code.Text.ToQueryString();

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
            if (Room_Code.Text.Trim() != "" && this.Text == "Add")
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
