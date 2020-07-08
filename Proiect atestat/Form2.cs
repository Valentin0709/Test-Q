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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(Globals.con);
            string query = "Select * from [Users] Where Username = '" + textBox5.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count > 0) MessageBox.Show("Numele de utilizator este deja luat!");
            else
            {
                try
                {
                    string commString = "INSERT INTO [Users](Last_Name, First_Name, Birthday, Email, Username, Password) VALUES(@val1, @val2, @val3, @val4, @val5, @val6)";
                    string conString = Globals.con;
                    using (SqlConnection conn = new SqlConnection(conString))
                    {
                        using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = commString;
                            comm.Parameters.AddWithValue("@val1", textBox1.Text);
                            comm.Parameters.AddWithValue("@val2", textBox2.Text);
                            comm.Parameters.AddWithValue("@val3", textBox3.Text);
                            comm.Parameters.AddWithValue("@val4", textBox4.Text);
                            comm.Parameters.AddWithValue("@val5", textBox5.Text);
                            comm.Parameters.AddWithValue("@val6", textBox6.Text);
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }

                    conString = Globals.con;
                    commString = "CREATE TABLE [dbo].[" + textBox5.Text + " joc1" + "] ([Date] DATETIME NOT NULL PRIMARY KEY, [Scor] INT NOT NULL)";
                    Console.WriteLine(commString);
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
                    commString = "CREATE TABLE [dbo].[" + textBox5.Text + " joc2" + "] ([Date] DATETIME NOT NULL PRIMARY KEY, [Scor] INT NOT NULL)";
                    Console.WriteLine(commString);
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
                    commString = "CREATE TABLE [dbo].[" + textBox5.Text + " joc3" + "] ([Date] DATETIME NOT NULL PRIMARY KEY, [Scor] INT NOT NULL)";
                    Console.WriteLine(commString);
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

                    commString = "CREATE TABLE [dbo].[" + textBox5.Text + " prieteni" + "] ([Username] VARCHAR(50) NOT NULL PRIMARY KEY, [Rel] INT NOT NULL)";
                    Console.WriteLine(commString);
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


                    MessageBox.Show("Inregistrarea a fost realizata cu succes!");
                    Form1 f1 = new Form1();
                    this.Hide();
                    f1.Show();
                }
                catch { MessageBox.Show("A avut loc o eroare la inregistrare :("); }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
