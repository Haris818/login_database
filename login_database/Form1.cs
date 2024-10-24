using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace login_database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=DESKTOP-B8AO3PN;Initial Catalog=account;Integrated Security=True";

            string fname = Email.Text;
            string pass = Password.Text;


            using (SqlConnection con = new SqlConnection(connString))
            {
                try
                {
                    con.Open();


                    string query = "INSERT INTO login_table (email, pass) VALUES ('"+fname+"', '"+pass+"')";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Email", fname);
                        cmd.Parameters.AddWithValue("@Password", pass);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data Saved");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connect = "Data Source=DESKTOP-B8AO3PN;Initial Catalog=account;Integrated Security=True";
            string delete = tbdelete.Text;

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                string query = "DELETE FROM login_table WHERE email = '" + delete + "'";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@email",delete);

                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Email is deleted");
                        }
                        else
                        {
                            MessageBox.Show("Email is not confirmed");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void tbdelete_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }



