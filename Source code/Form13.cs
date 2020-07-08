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

namespace Proiect_atestat
{
    public partial class Form13 : Form
    {
        string username;
        public Form13(string u)
        {
            InitializeComponent();
            username = u; 
            label1.Text = username;

            SqlConnection sqlcon = new SqlConnection(Globals.con);
            List<string> items = new List<string>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [" + username + " prieteni]", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string commString, conString;
            foreach (DataRow dr in dt.Rows)
            {
                if (Int32.Parse(dr["Rel"].ToString()) == 1) items.Add(dr["Username"].ToString());
                else {
                    DialogResult d = MessageBox.Show("Accepti cerererea de prietenie a lui " + dr["Username"].ToString() + " ?", "Cerere de prietenie", MessageBoxButtons.YesNo);
                    string pr = dr["Username"].ToString();
                    commString = "DELETE FROM [" + username + " prieteni] WHERE Username =" + "'" + pr + "'";
                    conString = Globals.con;
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = commString;
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                    commString = "DELETE FROM [" + pr + " prieteni] WHERE Username =" + "'" + username + "'";
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = commString;
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                    if (d == DialogResult.Yes)
                    {
                        commString = "INSERT INTO [" + username + " prieteni](Username, Rel) VALUES (@val1, @val2)";
                        using (SqlConnection conn = new SqlConnection(conString))
                        {
                            using (SqlCommand comm = new SqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = commString;
                                comm.Parameters.AddWithValue("@val1",pr);
                                comm.Parameters.AddWithValue("@val2", 1);
                                conn.Open();
                                comm.ExecuteNonQuery();
                            }
                        }
                        commString = "INSERT INTO [" + pr + " prieteni](Username, Rel) VALUES (@val1, @val2)";
                        using (SqlConnection conn = new SqlConnection(conString))
                        {
                            using (SqlCommand comm = new SqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = commString;
                                comm.Parameters.AddWithValue("@val1", username);
                                comm.Parameters.AddWithValue("@val2", 1);
                                conn.Open();
                                comm.ExecuteNonQuery();
                            }
                        }
                        items.Add(dr["Username"].ToString());
                    }


                }
            }
            listBox1.DataSource = items;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13(username);
            this.Hide();
            f13.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(username);
            this.Hide();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(username);
            this.Hide();
            f6.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(username, username);
            this.Hide();
            f12.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection(Globals.con);
            string query = "Select * from [Users] Where Username = '" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1 && !username.Equals(textBox1.Text))
            {
                query = "Select * from [" + username + " prieteni] Where Username = '" + textBox1.Text + "'";
                sda = new SqlDataAdapter(query, sqlcon);
                dtb1 = new DataTable();
                sda.Fill(dtb1);
                if (dtb1.Rows.Count == 1) MessageBox.Show("Sunteti deja prieteni sau ati trimis deja o cerere de prietenie");
                else
                {
                    string commString = "INSERT INTO [" + username + " prieteni](Username, Rel) VALUES (@val1, @val2)";
                    string conString = Globals.con;
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = commString;
                            comm.Parameters.AddWithValue("@val1", textBox1.Text);
                            comm.Parameters.AddWithValue("@val2", 0);
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }

                    commString = "INSERT INTO [" + textBox1.Text + " prieteni](Username, Rel) VALUES (@val1, @val2)";
                    conString = Globals.con;
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = commString;
                            comm.Parameters.AddWithValue("@val1",username);
                            comm.Parameters.AddWithValue("@val2", 0);
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Cererea de prietenie a fost trimisa!");
                }
            }
            else {
                MessageBox.Show("Numele de utilizator introus este invalid");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string pr = listBox1.GetItemText(listBox1.SelectedItem);
            Form12 f12 = new Form12(username, pr);
            this.Hide();
            f12.Show();
        }

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string pr = listBox1.GetItemText(listBox1.SelectedItem);

            string commString = "DELETE FROM [" + username + " prieteni] WHERE Username =" + "'" + pr + "'";
            string conString = Globals.con;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = commString;
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }
            commString = "DELETE FROM [" + pr + " prieteni] WHERE Username =" + "'" + username + "'";
            using (SqlConnection conn = new SqlConnection(conString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = commString;
                    conn.Open();
                    comm.ExecuteNonQuery();
                }
            }
            Form13 f13 = new Form13(username);
            this.Hide();
            f13.Show();

        }
    }
}
