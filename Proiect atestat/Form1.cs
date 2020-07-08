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

    public partial class Form1 : Form
    {
        string username;
        public Form1()
        {
                InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(Globals.con);
            string query = "Select * from [Users] Where Username = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            if (dtb1.Rows.Count == 1)
            {
                DataRow dr = dtb1.Rows[0];
                username = dr["Username"].ToString();
                Form3 f3 = new Form3(username);
                this.Hide();
                f3.Show();
            }
            else MessageBox.Show("Eroare la autentificare! Numele de utilizator sau parola introdusa nu sunt corecte.");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
