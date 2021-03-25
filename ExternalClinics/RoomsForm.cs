using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ExternalClinics
{
    public partial class RoomsForm : Form
    {
        public static Dictionary<string, object> roomObj = new Dictionary<string, object>();
        public RoomsForm()
        {
            InitializeComponent();
            fillRooms();
        }

        private void fillRooms()
        {
            string strsql = "select Room_Code, Room_Desc, ";
            strsql += "CASE WHEN Room_Status = 'A' then 'Active' else 'Inactive' END as [Room_Status] ";
            strsql += "from tbl_Rooms ";

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
                                    dataGridView1.DataSource = dt;
                                    dataGridView1.Dock = DockStyle.Fill;

                                    dataGridView1.Columns[0].HeaderText = "";
                                    dataGridView1.Columns[0].Width = 50;
                                    dataGridView1.Columns[1].HeaderText = "Code";
                                    dataGridView1.Columns[1].Width = 200;
                                    dataGridView1.Columns[2].HeaderText = "Description";
                                    dataGridView1.Columns[2].Width = 400;
                                    dataGridView1.Columns[3].HeaderText = "Status";
                                    dataGridView1.Columns[3].Width = 200;
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
            using (RoomsAdd frm = new RoomsAdd())
            {
                frm.Owner = this;
                frm.ShowDialog();
                fillRooms();
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

                roomObj.Add("Room_Code", row.Cells["Room_Code"].Value);
                roomObj.Add("Room_Desc", row.Cells["Room_Desc"].Value);
                roomObj.Add("Room_Status", row.Cells["Room_Status"].Value);

                using (RoomsAdd frm = new RoomsAdd())
                {
                    frm.Text = "Edit";
                    frm.Owner = this;
                    frm.ShowDialog();
                    fillRooms();
                    roomObj.Clear();
                }
            }
        }
    }
}
