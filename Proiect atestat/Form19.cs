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
    public partial class Form19 : Form
    {
        string username, pr;
        public Form19(string u, string p)
        {
            InitializeComponent();
            username = u; pr = p;
            label1.Text = username;

            if (username.Equals(pr)) button4.BackColor = Color.FromArgb(0, 93, 200);
            else button3.BackColor = Color.FromArgb(0, 93, 200);

            int[] a = new int[51];
            double smed = 0; int nr = 0;


            SqlConnection sqlcon = new SqlConnection(Globals.con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [" + p + " joc3]", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int x = Int32.Parse(dr["Scor"].ToString());
                DateTime d = Convert.ToDateTime(dr["Date"].ToString());
                chart1.Series["Scor"].Points.AddXY(d, x);
                nr++; smed += x;
            }
            smed = smed / nr;

            label10.Text = "Scorul mediu: " + Math.Round(Double.Parse(Convert.ToString(smed)), 2, MidpointRounding.AwayFromZero);

            string query = "SELECT TOP(1) Scor FROM [" + p + " joc3] ORDER BY Scor DESC";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            DataRow row = dtb1.Rows[0];

            label11.Text = "Scorul cel mai bun: " + row["Scor"].ToString();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18(username, pr);
            this.Hide();
            f18.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
