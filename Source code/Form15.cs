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
    public partial class Form15 : Form
    {
        string username;

        public Form15(string u)
        {
            InitializeComponent();
            username = u;
            label5.Text = username;

            SqlConnection sqlcon = new SqlConnection(Globals.con);
            string query = "SELECT TOP(1) Scor FROM [" + username + " joc3]" + " ORDER BY Date DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            DataRow row = dtb1.Rows[0];
            string uscor = row["Scor"].ToString();

            label8.Text = uscor;

            query = "SELECT TOP(1) Scor FROM [" + username + " joc3]" + " ORDER BY Scor DESC";
            sda = new SqlDataAdapter(query, sqlcon);
            dtb1 = new DataTable();
            sda.Fill(dtb1);
            row = dtb1.Rows[0];
            string pmaxscor = row["Scor"].ToString();

            label9.Text = pmaxscor;

            query = "SELECT TOP(1) Scor FROM [Joc3] ORDER BY Scor DESC";
            sda = new SqlDataAdapter(query, sqlcon);
            dtb1 = new DataTable();
            sda.Fill(dtb1);
            row = dtb1.Rows[0];
            string maxscor = row["Scor"].ToString();

            label10.Text = maxscor;
        }


        private void Form15_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13(username);
            this.Hide();
            f13.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(username, username);
            this.Hide();
            f12.Show();
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
    }
}
