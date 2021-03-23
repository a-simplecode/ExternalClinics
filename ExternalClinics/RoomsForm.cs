using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ExternalClinics
{
    public partial class RoomsForm : Form
    {
        public RoomsForm()
        {
            InitializeComponent();
            fillRooms();
        }

        private void fillRooms()
        {
            string strsql = "select Room_Code as [Code], Room_Desc as [Description], CASE WHEN Room_Status = 'A' then 'Active' else 'Inactive' END as [Status] ";
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
                                dataGridView1.DataSource = dt;
                                dataGridView1.Dock = DockStyle.Fill;
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
    }
}
