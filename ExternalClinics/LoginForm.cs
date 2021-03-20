using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace ExternalClinics
{
    public partial class LoginForm : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public LoginForm()
        {
            InitializeComponent();


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (password.Text.Trim() != "" && userName.Text.Trim() != "")
            {

                try
                {
                    Object response;
                    String query = "select * from tbl_Users where User_Code = " + userName.Text.ToQueryString();
                    query += " and User_Password = " + password.Text.ToQueryString();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            response = command.ExecuteScalar();
                            if (response == null)
                            {
                                MessageBox.Show("Wrong Username Or Password", "Alert");
                            }
                            else
                            {
                                DashboardForm newform = new DashboardForm();
                                this.Hide();
                                newform.ShowDialog();
                                if (newform.DialogResult == DialogResult.Cancel)
                                {
                                    this.Close();
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
            else
            {
                MessageBox.Show("Username Or Password are Empty", "Alert");
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }
    }
}
