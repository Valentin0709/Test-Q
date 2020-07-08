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
    public partial class Form16 : Form
    {
        string username;
        public Form16(string u)
        {
            InitializeComponent();
            username = u;
            label1.Text = username;

            int[] a = new int[51];
            double smed = 0; int nr = 0;
            for (int i = 0; i <= 50; i++) a[i] = 0;

            SqlConnection sqlcon = new SqlConnection(Globals.con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Joc3]", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int x = Int32.Parse(dr["Scor"].ToString());
                if (x < 1000) a[x/20]++;
                else a[50]++;
                nr++; smed += x;
            }
            smed = smed / nr;

            label12.Text = "Scorul mediu obtinut de un jucator este: " +  Convert.ToString(Math.Round(Double.Parse(Convert.ToString(smed)), 2, MidpointRounding.AwayFromZero));

            for (int i = 0; i < 50; i++)
            {
                chart1.Series["Scor"].Points.AddXY(i*20, a[i]);
            }

            string query = "SELECT TOP(1) Scor FROM [Joc3] ORDER BY Scor DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            DataRow row = dtb1.Rows[0];

            string scor = row["Scor"].ToString();

            query = "SELECT TOP(1) Username FROM [Joc3] ORDER BY Scor DESC";
            sda = new SqlDataAdapter(query, sqlcon);
            dtb1 = new DataTable();
            sda.Fill(dtb1);
            row = dtb1.Rows[0];

            string user = row["Username"].ToString();

            query = "SELECT TOP(1) Date FROM [Joc3] ORDER BY Scor DESC";
            sda = new SqlDataAdapter(query, sqlcon);
            dtb1 = new DataTable();
            sda.Fill(dtb1);
            row = dtb1.Rows[0];

            DateTime d = Convert.ToDateTime(row["Date"].ToString());

            label6.Text = "Cel mai bun scor este " + scor + " si a fost obtinut de " + user + " pe data de " + d.ToString("yyyy-MM-dd");

            chart1.ChartAreas[0].AxisX.Title = "Scor";
            chart1.ChartAreas[0].AxisY.Title = "Numar de jucatori";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
          
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(username);
            this.Hide();
            f3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
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

        private void label3_Click_1(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form22 f22 = new Form22(username);
            this.Hide();
            f22.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form16_Load(object sender, EventArgs e)
        {

        }
    }
}
